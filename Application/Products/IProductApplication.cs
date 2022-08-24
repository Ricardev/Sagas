using Application.Products.Models;
using MessageBroker.EventModels;

namespace Application.Products;

public interface IProductApplication
{
    public void CreateProduct(ProductModel productModel);
    public void OrderProduct(ReserveProductEventModel order);
    public void RollbackOrderProduct(RollbackPaymentEventModel paymentEvent);
    public ICollection<ProductModel> ObterProdutos();
}