# Sagas

Principais features, frameworks e servicos utilizados nesse projeto:
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

O seguinte projeto tem a finalidade de exemplificar o padrao Sagas Choreography Architecture em um ambiente de micro servicos. Porem, para deixar o projeto mais robusto e um pouco mais complexo, assemelhando-se a realidade, implementei algumas outras ferramentas para mostrar como elas se comunicam.

O Saga Architecture e um padrao arquitetural que possui a finalidade de otimizar a comunicacao entre os micro servicos a fim de manter a integridade do banco de dados.
Como assim?
Cada micro servico tem o seu proprio banco de dados, e existe algumas operacoes que necessitam de transacoes entre micro servicos, cada um dando um commit no seu proprio banco. 
Por exemplo ( e justamente o exemplo que implementamos nesse repositorio ): Quando uma usuario faz uma compra na internet, ele emite um pedido de compra ( Servico de Pedidos ), essa compra precisa saber se todos os produtos naquele carrinho ou pedido estao disponiveis para venda ( Servico de Produtos ) e por ultimo emitir uma nota de pagamento ( Servico de Pagamento ). Ocorre que todos esses micro servicos fazem transacoes no seu proprio banco de dados e o problema e: e se ocorrer alguma falha em qualquer uma dessas transacoes? Os outros dados irao persistir no seu banco ate que voce tome uma medida contra isso. E pra isso serve a arquitetura Saga, para que caso ocorra uma falha em qualquer uma dessas transacoes, todas as transacoes anteriores possam dar um rollback.

E como nos implementamos isso?

Ponto primordial: os micro servicos precisam se comunicar, para que quando uma transacao ocorra com sucesso, ele passe essa informacao para o proximo micro servico e quando ela falhe, os anteriores deem rollback. Para isso ha duas abordagens para pensarmos:
  - Requisicao HTTP.
  - Eventos/Mensagens

A primeira abordagem consiste em chamar a controladora do outro servico sempre que a transacao for concluida, e como toda abordagem, tem os seus contras.
No meu caso, eu estou utilizando o Service Discovery para o registro de servicos e portanto nao preciso deixar nenhuma porta ou endereco 'hard-coded'.
Alem disso, nessa abordagem, o servico requisitado precisa obrigatoriamente estar disponivel no momento em que for chamado. Com o plus de que voce vai ter que fazer muito mais endpoints para lidar com esses casos.

A segunda abordagem foi a escolhida para este repositorio.
Nos nao precisamos nos preocupar com enderecos IP's, portas ou se o servico estara disponivel no momento em que o anterior realizou sua transacao.

Para realizar a comunicacao entre os micro servicos, foi utilizado o RabbitMQ. O componente poderia ser substituido pelo SQS ou Kafka se fosse hospedado na Cloud.
Ademais, foi utilizado o BackgroundService para ficar rodando em segundo plano e ouvindo quando as mensagens pertinentes aquele servico chegou. Novamente, se fosse hospedado na Cloud, poderiamos substituir essa abordagem por Lambdas Functions ou Azure Functions.



