namespace Domain.Order;

public class Order
{
    public int Id { get; }
    public int UserId { get; private set; }
    public int ProductId { get; private set; }
    public int Quantity { get; private set; }

    public void SetUserId(int id) => UserId = id;
    public void SetProductId(int id) => ProductId = id;

    public void SetQuantity(int quantity) => Quantity = quantity;
}
