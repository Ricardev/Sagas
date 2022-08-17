using Application.Order.Models;

namespace Application.Order;

public interface IOrderApplication
{
    Task MakeOrder(MakeOrderModel orderModel);
}