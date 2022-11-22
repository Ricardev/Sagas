namespace MessageBroker.EventModels;

public class CreatePaymentEventModel
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int PaymentValue { get; set; }
}