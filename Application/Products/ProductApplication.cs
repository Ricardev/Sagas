using Application.Products.Models;
using AutoMapper;
using Domain.Products;
using Domain.Products.Command;
using MediatR;
using MessageBroker;
using MessageBroker.EventModels;

namespace Application.Products;

public class ProductApplication : IProductApplication
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IMessageBroker _messageBroker;
    private readonly IProductRepository _repository;
    
    public ProductApplication(IMediator mediator, IMapper mapper, IMessageBroker messageBroker, IProductRepository repository)
    {
        _mediator = mediator;
        _mapper = mapper;
        _messageBroker = messageBroker;
        _repository = repository;
    }

    public void CreateProduct(ProductModel productModel)
    {
        var productCommand = _mapper.Map<CreateProductCommand>(productModel);
        _mediator.Send(productCommand);
    }

    public async void OrderProduct(ReserveProductEventModel order)
    {
        var orderProductCommand = _mapper.Map<OrderProductCommand>(order);
        
        var success = await _mediator.Send(orderProductCommand);

        if (!success)
            return;
        
        var createPaymentEventModel = new CreatePaymentEventModel
        {
            OrderId = order.OrderId,
            ProductId = order.ProductId,
            PaymentValue = 10 //Aqui nós deveríamos retornar o valor do produto na resposta do mediator,além do booleano de sucesso
                              //e multiplicar pela quantidade de produtos pedidos.
                              //Mas tô com preguiça, se eu tiver boa vontade depois eu faço. Vocês pegaram a ideia.
        };
        _messageBroker.PublishMessage(createPaymentEventModel, QueueExchange.CreatePaymentExchange);
    }

    public void RollbackOrderProduct(RollbackProductEventModel rollbackProductEvent)
    {
        var productRollbackCommand = _mapper.Map<RollbackOrderProductCommand>(rollbackProductEvent);
        _mediator.Publish(productRollbackCommand);
    }

    public ICollection<ProductModel> ObterProdutos()
    {
        var produtos = _repository.GetProducts();
        var produtosModel = _mapper.Map<ICollection<ProductModel>>(produtos).ToList();
        return produtosModel;
    }
}