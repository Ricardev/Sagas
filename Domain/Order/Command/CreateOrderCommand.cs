using MediatR;

namespace Domain.Order.Command;

public class CreateOrderCommand : IRequest
{
    private int UserId { get; }
    private int ProductId { get; }
    private int Quantity { get; }
}