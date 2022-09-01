# Sagas

Principais features, frameworks e serviços utilizados nesse projeto:
  - Sagas Choreography Architecture
  - Domain Driven Design
  - Arquitetura em Camadas
  - CQRS
  - Micro Servicos
  - Mensageria com RabbitMQ
  - Api Gateway com Ocelot
  - Service Discovery com Eureka
  - Bancos de Dados Relacionais com PostgreSQL
  - Orquestracao de Containers com Docker
  - Autenticacao

# Explicação Inicial

O seguinte projeto tem a finalidade de exemplificar o padrão Sagas Choreography Architecture em um ambiente de micro serviços. Porém, para deixar o projeto mais robusto e um pouco mais complexo, assemelhando-se à realidade, implementei algumas outras ferramentas para mostrar como elas se comunicam.

O Saga Architecture é um padrao arquitetural que possui a finalidade de otimizar a comunicação entre os micro serviços a fim de manter a integridade do banco de dados.
Como assim?
Cada micro serviço tem o seu próprio banco de dados, e existem algumas operações que necessitam de transações entre micro serviços, cada um dando um commit no seu próprio banco. 
Por exemplo ( e justamente o exemplo que implementamos nesse repositório ): Quando uma usuário faz uma compra na internet, ele emite um pedido de compra ( Serviço de Pedidos ), essa compra precisa saber se todos os produtos naquele carrinho ou pedido estao disponíveis para venda ( Servico de Produtos ) e por ultimo emitir uma nota de pagamento ( Servico de Pagamento ). Ocorre que todos esses serviços fazem transações no seu proprio banco de dados e o problema é: e se ocorrer alguma falha em qualquer uma dessas transações? Todos os commits feitos irão persistir no seu banco até que você tome uma medida contra isso. E para isso serve a arquitetura Saga, para que caso ocorra uma falha em qualquer uma dessas transações, todas as anteriores possam dar um rollback.
E o princípio para isso é: Para cada transação implementada, deverá existir uma transação compensatória.
Então se eu faço uma compra e esta, por sua vez, reserva um produto no estoque até que eu pague por ela, eu preciso de uma ação de compensação que coloque de volta esse produto no estoque se der um problema com a emissão do boleto ou o período de pagamento determinado esteja expirado.

# E como nós implementamos isso?

Ponto primordial: os micro serviços precisam se comunicar, para que quando uma transação ocorra com sucesso, ele passe essa informacao para o proximo micro serviço e quando ela falhar, os anteriores deem rollback. Para isso há duas abordagens para pensarmos:
  - Requisição HTTP.
  - Eventos/Mensagens

A primeira abordagem consiste em chamar a controladora do outro serviço sempre que a transação for concluída, e como toda abordagem, tem os seus contras.
No meu caso, eu estou utilizando o Service Discovery para o registro de serviços e portanto não preciso deixar nenhuma porta ou endereço 'hard-coded'.
Além disso, nessa abordagem, o servico requisitado precisa obrigatoriamente estar disponível no momento em que for chamado. Com o plus de que voce vai ter que fazer muito mais endpoints para lidar com esses casos.

A segunda abordagem foi a escolhida para este repositorio.
Nós não precisamos nos preocupar com endereços IP's, portas ou se o servico estara disponivel no momento em que o anterior realizou sua transacao.

Para realizar a comunicação entre os micro serviços, foi utilizado o RabbitMQ. O componente poderia ser substituido pelo SQS ou Kafka se fosse hospedado na Cloud.
Ademais, foi utilizado o BackgroundService para ficar rodando em segundo plano e ouvindo quando as mensagens pertinentes aquele servico chegaram. Novamente, se fosse hospedado na Cloud, poderiamos substituir essa abordagem por Lambdas Functions ou Azure Functions.


Então, nós temos nosso serviço de mensageria chamado de MessageBroker. Ele possui uma interface e uma implementação. O código para o consumo do RabbitMq se encontra nele e todo serviço que queira publicar ou receber mensagens, precisa chamar ele. Além disso, nele estão concentrados os nomes das filas que os serviços irão publicar/consumir, com as models que irão publicar e retornar.
Tudo que temos que fazer agora é, sempre que quisermos criar um novo evento, criar dentro de EventModels os seus atributos, e criar o nome de sua fila específica.

Para conseguirmos rodar os repositórios, recomendo utilizar o docker com o comando "docker-compose up" na raiz do projeto.

