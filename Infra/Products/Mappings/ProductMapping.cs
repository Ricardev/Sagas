using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Products.Mappings;

public class ProductMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Id).HasColumnName("ProductId");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        
        builder.Property(x => x.Value)
            .HasColumnName("Value");

        builder.Property(x => x.StockQuantity)
            .HasColumnName("StockQuantity");

        builder.Property(x => x.Name)
            .HasColumnName("Name");
        
        builder.HasMany(x => x.Orders)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId);



        builder.ToTable("Product", schema: "ProductSchema");
    }
}