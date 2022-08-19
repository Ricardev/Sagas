namespace Domain.Order.Shared;

public class User
{
    public int UserId { get; private set; }
    public virtual ICollection<Order> Orders { get; private set; }
}