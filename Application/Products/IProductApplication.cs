using Application.Products.Models;
using MessageBroker.EventModels;

namespace Application.Products;

public interface IProductApplication
{
    public void CreateProduct(ProductModel productModel);
    public void OrderProduct(ReserveProductEventModel orderProductEvent);
    public void RollbackOrderProduct(RollbackProductEventModel rollbackProductEvent);
    public ICollection<ProductModel> ObterProdutos();
}