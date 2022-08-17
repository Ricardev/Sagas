using MediatR;

namespace Domain.Products.Command;

public class CreateProductCommand : IRequest
{
    public int Value { get; private set; }
    public int StockQuantity { get; private set; }
}