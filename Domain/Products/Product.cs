using Domain.Products.Shared;

namespace Domain.Products;

public class Product
{
    public int Id { get; }
    public int Value { get; private set; }
    public int StockQuantity { get; private set; }
    
    public virtual ICollection<Order> Orders { get; private set; }

    public void ReserveProduct() => this.StockQuantity--;
    public void CancelProductReservation() => StockQuantity--;

    public void SetProductQuantity(int quantity) => StockQuantity = quantity;
    public void SetProductValue(int value) => Value = value;
    
}