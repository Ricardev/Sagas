using Domain.Products.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Products.Mappings;

public class OrderMapping : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(x => x.OrderId);
        builder.HasKey(x => x.OrderId);

        builder.HasOne(x => x.Product)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.ProductId);

        builder.ToTable("Order", schema: "OrderSchema");
    }
}