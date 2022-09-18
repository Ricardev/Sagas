using MediatR;

namespace Domain.Products.Command;

public class RollbackOrderProductCommand : IRequest
{
    public int ProductId { get; set; }
    public int OrderId { get; set; }
}