namespace Domain.Products.Builders;

public class ProductBuilder
{
    private readonly Product _product;

    public ProductBuilder()
    {
        _product = new Product();
    }

    public ProductBuilder SetProductValue(int value)
    {
        _product.SetProductValue(value);
        return this;
    }

    public ProductBuilder SetProductQuantity(int quantity)
    {
        _product.SetProductQuantity(quantity);
        return this;
    }

    public ProductBuilder ReserveProduct()
    {
        _product.ReserveProduct();
        return this;
    }

    public Product Build() => _product;
}