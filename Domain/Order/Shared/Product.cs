namespace Domain.Order.Shared;

public class Product
{
    public int Id { get; }
    public virtual ICollection<Order> Orders { get; private set; }
}