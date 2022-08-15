using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace Infra.User.Context;

public class UserContext : DbContext
{

    public DbSet<Domain.User.User> User;

    public UserContext() {}
    public UserContext(DbContextOptions options) : base(options) {}
    
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