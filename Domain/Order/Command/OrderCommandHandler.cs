using MediatR;
using MessageBroker;

namespace Domain.Order.Command;

public class OrderCommandHandler : INotificationHandler<CreateOrderCommand>
{
    private readonly IOrderRepository _repository;

    public OrderCommandHandler(IOrderRepository repository, IMessageBroker messageBroker)
    {
        _repository = repository;
    }
    
    public Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        try
        {
            _repository.CreateOrder(new Order());
            return Task.CompletedTask;
        }
        catch
        {
            return Task.FromException(new Exception("Deu ruim"));
        }

    }
}

