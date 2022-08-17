namespace Domain.Order.Builders;

public class OrderBuilder
{
    private readonly Order _order;

    public OrderBuilder()
    {
        _order = new Order();
    }

    public OrderBuilder SetUserId(int userId)
    {
        _order.SetUserId(userId);
        return this;
    }

    public OrderBuilder SetProductId(int productId)
    {
        _order.SetProductId(productId);
        return this;
    }

    public OrderBuilder SetQuantity(int quantity)
    {
        _order.SetQuantity(quantity);
        return this;
    }

    public Order Builder() => _order;
    
}