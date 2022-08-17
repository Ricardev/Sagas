using Domain.Order.Builders;
using MediatR;
using MessageBroker;

namespace Domain.Order.Command;

public class OrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
{
    private readonly IOrderRepository _repository;

    public OrderCommandHandler(IOrderRepository repository, IMessageBroker messageBroker)
    {
        _repository = repository;
    }

    public Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var order = new OrderBuilder()
                .SetQuantity(request.Quantity)
                .SetProductId(request.ProductId)
                .SetUserId(request.UserId)
                .Builder();
            var createdOrder = _repository.CreateOrder(order);
            return Task.FromResult(createdOrder.Id);
        }
        catch
        {
            return Task.FromResult(-1);
        }
    }
}

