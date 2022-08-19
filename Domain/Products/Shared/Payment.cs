namespace Domain.Products.Shared;

public class Payment
{
    public int Id { get; private set; }
    public virtual Product Product { get; private set; }
    public virtual Order Order { get; private set; }
}