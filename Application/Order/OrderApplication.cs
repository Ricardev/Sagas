using Application.Order.Models;
using AutoMapper;
using Domain.Order.Command;
using MediatR;

namespace Application.Order;

public class OrderApplication : IOrderApplication
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public OrderApplication(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }
    
    public bool MakeOrder(MakeOrderModel orderModel)
    {
        var makeOrderCommand = _mapper.Map<CreateOrderCommand>(orderModel);
        _mediator.Publish(makeOrderCommand);
        
        throw new NotImplementedException();
    }
}