namespace Application.Order.Models;

public class MakeOrderModel
{
    public int UserId { get => 1; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}