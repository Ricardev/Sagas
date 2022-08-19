using Domain.Payment.Shared;

namespace Domain.Payment;

public class Payment
{
    public int Id { get; private set; }
    public int PaymentValue { get; private set; }
    public virtual Product Product { get; private set; }
    public int ProductId { get; private set; }
    public virtual Order Order { get; private set; }
    public int OrderId { get; private set;  }


    public void SetPaymentValue(int value) => PaymentValue = value;

    public void SetOrderId(int id) => OrderId = id;
}