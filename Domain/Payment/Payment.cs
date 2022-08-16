namespace Domain.Payment;

public class Payment
{
    public int Id { get; }
    public int PaymentValue { get; }
    public int OrderId { get; }
}