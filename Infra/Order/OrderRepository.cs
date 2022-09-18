using Domain.Order;
using Infra.Order.Context;

namespace Infra.Order;

public class OrderRepository : IOrderRepository
{
    private readonly OrderContext _context;

    public OrderRepository(OrderContext context)
    {
        _context = context;
    }
    public Domain.Order.Order CreateOrder(Domain.Order.Order order)
    {
        var createdOrder = _context.Set<Domain.Order.Order>().Add(order).Entity;
        _context.SaveChanges();
        return createdOrder;
    }
}