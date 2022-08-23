namespace Domain.Products;

public interface IProductRepository
{

    public Product? GetProduct(int id);
    public ICollection<Product> GetProducts();
    public void CreateProduct(Product product);

    public Product OrderProduct(Product product);
}