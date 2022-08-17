using Domain.Products;
using Infra.Products.Context;

namespace Infra.Products;

public class ProductRepository : IProductRepository
{
    private readonly ProductContext _context;

    public ProductRepository(ProductContext context)
    {
        _context = context;
    }
    
    public Product? GetProduct(int id)
    {
        return _context.Set<Product>().FirstOrDefault(x => x.Id.Equals(id));
    }

    public void CreateProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public Product OrderProduct(Product product)
    {
        throw new NotImplementedException();
    }
}