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

    public void OrderProduct(CreateOrderEventModel order)
    {
        var createProductCommand = _mapper.Map<OrderProductCommand>(order);
        
        _mediator.Publish(createProductCommand);
        
        var validateProductEventModel = new ValidateProductEventModel()
        {
            OrderId = order.OrderId,
            ProductId = order.ProductId
        };
        
        _messageBroker.PublishMessage(validateProductEventModel, EventQueue.CreatePaymentQueue, "Product Exchange");
    }

    public void RollbackOrderProduct()
    {
        throw new NotImplementedException();
    }

    public ICollection<ProductModel> ObterProdutos()
    {
        var produtos = _repository.GetProducts();
        var produtosModel = _mapper.Map<ICollection<ProductModel>>(produtos).ToList();
        return produtosModel;
    }
}