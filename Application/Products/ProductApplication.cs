using MediatR;

namespace Application.Products;

public class ProductApplication : IProductApplication
{
    private readonly IMediator _mediator;
    
    public ProductApplication(IMediator mediator)
    {
        _mediator = mediator;
    }
}