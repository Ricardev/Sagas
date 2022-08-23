using Application.Order.Models;
using AutoMapper;
using Domain.Order;
using Domain.Order.Command;
using MediatR;
using MessageBroker;
using MessageBroker.EventModels;

namespace Application.Order;

public class OrderApplication : IOrderApplication
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly IMessageBroker _messageBroker;
    private readonly IOrderRepository _repository;

    public OrderApplication(IMapper mapper, IMediator mediator, IMessageBroker messageBroker, IOrderRepository repository)
    {
        _mapper = mapper;
        _mediator = mediator;
        _messageBroker = messageBroker;
        _repository = repository;
    }
    
    public async Task MakeOrder(MakeOrderModel orderModel)
    {
        var makeOrderCommand = _mapper.Map<CreateOrderCommand>(orderModel);
        var orderId = await _mediator.Send(makeOrderCommand);
        var createdOrderEvent = new CreateOrderEventModel(orderId, orderModel.UserId, orderModel.ProductId, orderModel.Quantity);
        _messageBroker.PublishMessage(createdOrderEvent,eventQueue: EventQueue.ValidateProductQueue, "Order Exchange");
    }
}