using Domain.Payment.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Payment.Mappings;

public class PaymentMapping : IEntityTypeConfiguration<Domain.Payment.Payment>
{
    public void Configure(EntityTypeBuilder<Domain.Payment.Payment> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnName("PaymentId");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.ProductId)
            .HasColumnName("ProductId");
        
        builder.Property(x => x.PaymentValue)
            .HasColumnName("PaymentValue");

        builder.Property(x => x.OrderId)
            .HasColumnName("OrderId");

        builder.HasOne(x => x.Order)
            .WithOne(x => x.Payment)
            .HasForeignKey<Order>(x => x.OrderId);
        
        builder.HasOne(x => x.Product)
            .WithMany(x => x.Payments)
            .HasForeignKey(x => x.Id);

        builder.ToTable("Payment", schema: "PaymentSchema");
    }
}