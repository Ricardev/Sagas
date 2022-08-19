namespace Domain.Order.Shared;

public class Payment
{
    public int Id { get; private set; }
    public int PaymentValue { get; private set; }
    public virtual Product Product { get; private set; }
    public int ProductId { get; private set; }
    public virtual Order Order { get; private set; }
    public int OrderId { get; private set;  }
}