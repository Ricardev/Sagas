using Infra.Payment.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra.Payment.Context;

public class PaymentContext : DbContext
{
    public DbSet<Domain.Payment.Payment> Payment;

    public PaymentContext() {}
    public PaymentContext(DbContextOptions options) : base(options) {}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PaymentMapping());
        modelBuilder.ApplyConfiguration(new OrderMapping());
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            ConfigDatabase(optionsBuilder);
        base.OnConfiguring(optionsBuilder);
    }
    
    private void ConfigDatabase(DbContextOptionsBuilder optionsBuilder)
    { 
        IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, false).Build();
        optionsBuilder.UseNpgsql(configuration.GetSection("DatabaseConnection")["ConnectionString"]!);
    }
}