using Domain.Products;
using Infra.Products.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra.Products.Context;

public class ProductContext : DbContext
{

    public DbSet<Product> Product;

    public ProductContext() {}
    public ProductContext(DbContextOptions options) : base(options) {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            ConfigDatabase(optionsBuilder);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductMapping());
        modelBuilder.ApplyConfiguration(new OrderMapping());
        base.OnModelCreating(modelBuilder);
    }

    private void ConfigDatabase(DbContextOptionsBuilder optionsBuilder)
    { 
        IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, false).Build();
        optionsBuilder.UseNpgsql(configuration.GetSection("DatabaseConnection")["ConnectionString"]!);
    }
}