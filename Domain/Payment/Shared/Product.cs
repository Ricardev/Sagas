namespace Domain.Payment.Shared;

public class Product
{
    public int ProductId { get; private set; }
    public ICollection<Order> Orders { get; private set; }
    public ICollection<Payment> Payments { get; private set; }
}