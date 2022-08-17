using System.Data;
using AutoMapper;
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
    
    public ProductApplication(IMediator mediator, IMapper mapper, IMessageBroker messageBroker)
    {
        _mediator = mediator;
        _mapper = mapper;
        _messageBroker = messageBroker;
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
        
        _messageBroker.PublishMessage(validateProductEventModel, EventQueue.CreatePaymentQueue);
    }

    public void RollbackOrderProduct()
    {
        throw new NotImplementedException();
    }
}