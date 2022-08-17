using MediatR;

namespace Domain.Products.Command;

public class OrderProductCommand : IRequest<bool>
{
    public int Id { get; set; }
}