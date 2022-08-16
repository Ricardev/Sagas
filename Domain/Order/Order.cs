namespace Sagas;

public class Order
{
    public int Id { get; }
    private int UserId { get; }
    private int ProductId { get; }
    private int Quantity { get; }
}