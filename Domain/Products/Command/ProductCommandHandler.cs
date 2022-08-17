using MediatR;

namespace Domain.Products.Command;

public class ProductCommandHandler : IRequestHandler<CreateProductCommand>, IRequestHandler<OrderProductCommand>, IRequestHandler<EditProductCommand>, IRequestHandler<DeleteProductCommand>
{
    private readonly IProductRepository _repository;

    public ProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }
    
    public Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        _repository.CreateProduct();
    }

    public Task<Unit> Handle(OrderProductCommand request, CancellationToken cancellationToken)
    {
        var product = _repository.GetProduct(request.Id);
        product.ReserveProduct();
        _repository.OrderProduct(product);
    }

    public Task<Unit> Handle(EditProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}