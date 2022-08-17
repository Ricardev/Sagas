namespace Domain.Payment;

public class Payment
{
    public int Id { get; private set; }
    public int PaymentValue { get; private set; }
    public int OrderId { get; private set;  }


    public void SetPaymentValue(int value) => PaymentValue = value;

    public void SetOrderId(int id) => OrderId = id;
}