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
        return _context.Add(order).Entity;
    }
}