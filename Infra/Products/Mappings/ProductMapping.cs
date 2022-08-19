using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Products.Mappings;

public class ProductMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Id);
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Value)
            .HasColumnName("Product_Value");

        builder.Property(x => x.StockQuantity)
            .HasColumnName("Stock_Quantity");
        
        builder.HasMany(x => x.Orders)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId);

        builder.ToTable("ProductTable", schema: "Product");
    }
}