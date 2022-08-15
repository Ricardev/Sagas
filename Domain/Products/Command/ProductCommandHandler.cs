using Domain.Products.Command;
using MediatR;

namespace Products.Command;

public class ProductCommandHandler : IRequestHandler<CreateProductCommand>, IRequestHandler<OrderProductCommand>, IRequestHandler<EditProductCommand>, IRequestHandler<DeleteProductCommand>
{
    public Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Unit> Handle(OrderProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
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