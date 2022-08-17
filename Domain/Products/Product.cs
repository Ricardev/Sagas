namespace Domain.Products;

public class Product
{
    public int Id { get; }
    public int Value { get; }
    public int StockQuantity { get; private set; }

    public void ReserveProduct() => this.StockQuantity--;
}