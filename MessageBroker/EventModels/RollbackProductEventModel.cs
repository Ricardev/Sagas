namespace MessageBroker.EventModels;

public class RollbackProductEventModel
{
    public int OrderId { get; }
    public int ProductId { get; }

    public RollbackProductEventModel( int orderId, int productId)
    {
        OrderId = orderId;
        ProductId = productId;
    }
}