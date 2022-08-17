namespace Domain.Order;

public interface IOrderRepository
{
    void CreateOrder(Order order);
}