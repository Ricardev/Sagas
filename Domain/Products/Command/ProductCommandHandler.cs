using Domain.Products.Builders;
using MediatR;

namespace Domain.Products.Command;

public class ProductCommandHandler : IRequestHandler<CreateProductCommand>, IRequestHandler<OrderProductCommand, bool>
{
    private readonly IProductRepository _repository;

    public ProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }
    
    public Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        
        var product = new ProductBuilder()
            .SetProductValue(request.Value).SetProductQuantity(request.StockQuantity).Build();
        _repository.CreateProduct(product);
        
        return Task.FromResult(Unit.Value);
    }

    public Task<bool> Handle(OrderProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var product = _repository.GetProduct(request.Id);
            
            if (product == null)
                return Task.FromResult(false);
            
            product.ReserveProduct();
            _repository.OrderProduct(product);
            return Task.FromResult(true);
        }
        catch
        {
            return Task.FromResult(false);
        }

    }
}