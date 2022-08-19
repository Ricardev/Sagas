using Domain.Order.Shared;

namespace Domain.Order;

public class Order
{
    public int Id { get; }
    public virtual User User { get; private set; }
    public int UserId { get; private set; }
    public virtual Product Product { get; private set; }
    public int ProductId { get; private set; }
    public virtual Payment Payment { get; private set; }
    public int PaymentId { get; private set; }
    public int Quantity { get; private set; }

    public void SetUserId(int id) => UserId = id;
    public void SetProductId(int id) => ProductId = id;

    public void SetQuantity(int quantity) => Quantity = quantity;
}
