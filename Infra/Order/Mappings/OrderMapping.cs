using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Order.Mappings;

public class OrderMapping : IEntityTypeConfiguration<Domain.Order.Order>
{
    public void Configure(EntityTypeBuilder<Domain.Order.Order> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnName("OrderId");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.Quantity)
            .HasColumnName("Quantity");
        
        builder.HasOne(x => x.Product)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.ProductId);
        
        builder.Property(x => x.ProductId)
            .HasColumnName("ProductId");

        builder.HasOne(x => x.User)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.UserId);
        
        builder.Property(x => x.UserId)
            .HasColumnName("UserId");
        
        builder.ToTable("Order", schema: "OrderSchema");
    }
}