namespace Domain.Payment.Shared;

public class Order
{
    public int OrderId { get; private set; }
    public virtual Payment Payment { get; private set; }
    public virtual Product Product { get; private set; }
    public int ProductId { get; private set; }
}