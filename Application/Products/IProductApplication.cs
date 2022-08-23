using Application.Products.Models;
using MessageBroker.EventModels;

namespace Application.Products;

public interface IProductApplication
{
    public void CreateProduct(ProductModel productModel);
    public void OrderProduct(CreateOrderEventModel order);
    public void RollbackOrderProduct();
    public ICollection<ProductModel> ObterProdutos();
}