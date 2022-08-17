namespace Domain.Order;

public interface IOrderRepository
{
    public Order CreateOrder(Order order);
}