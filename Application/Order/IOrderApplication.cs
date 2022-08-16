using Application.Order.Models;

namespace Application.Order;

public interface IOrderApplication
{
    bool MakeOrder(MakeOrderModel orderModel);
}