namespace MessageBroker.EventModels;

public class PaymentEventModel
{
    public int Id { get; }
    public int PaymentValue { get; }
    public int OrderId { get; }
    public int ProductId { get; }
}