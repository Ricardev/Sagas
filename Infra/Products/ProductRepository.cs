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

    public ICollection<Product> GetProducts()
    {
        return _context.Set<Product>().ToList();
    }

    public void CreateProduct(Product product)
    {
        _context.Set<Product>().Add(product);
        _context.SaveChanges();
    }

    public Product OrderProduct(Product product)
    {
        var productOrdered =_context.Set<Product>().Update(product).Entity;
        _context.SaveChanges();
        return productOrdered;
    }
}