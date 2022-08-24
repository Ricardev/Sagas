namespace MessageBroker.EventModels;

public class RollbackPaymentEventModel
{
    public int Id { get; }
    public int PaymentValue { get; }
    public int OrderId { get; }
    public int ProductId { get; }
}