using Domain.Payment.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Payment.Mappings;

public class OrderMapping : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasOne(x => x.Payment)
            .WithOne(x => x.Order);

        builder.Property(x => x.PaymentId)
            .HasColumnName("PaymentId");

        builder.HasOne(x => x.Product)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.ProductId);

        builder.ToTable("OrderTable", schema: "Order");
    }
}