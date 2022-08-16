using MediatR;

namespace Domain.Order.Command;

public class OrderCommandHandler : IRequestHandler<CreateOrderCommand>
{
    public Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}