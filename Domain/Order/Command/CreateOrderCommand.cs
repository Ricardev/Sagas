using MediatR;

namespace Domain.Order.Command;

public class CreateOrderCommand : IRequest<int>
{
    public int UserId { get; }
    public int ProductId { get; }
    public int Quantity { get; }
}