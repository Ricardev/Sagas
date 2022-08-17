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
    public void CreateOrder(Domain.Order.Order order)
    { 
        _context.Add(order);
    }
}