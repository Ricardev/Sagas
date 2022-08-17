using MessageBroker.EventModels;

namespace Application.Products;

public interface IProductApplication
{
    public void OrderProduct(CreateOrderEventModel order);
    public void RollbackOrderProduct();
}