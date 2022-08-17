using MediatR;

namespace Domain.Products.Command;

public class OrderProductCommand : IRequest
{
    public int Id { get; set; }
}