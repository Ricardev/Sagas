namespace MessageBroker.EventModels;

public class CreateOrderEventModel
{
    public int OrderId { get; }
    public int UserId { get; }
    public int ProductId { get; }
    public int Quantity { get; }
}