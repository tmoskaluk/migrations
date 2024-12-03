using Cars.Customers.Crud.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Cars.Customers.Crud;

public class CustomersDbContext(DbContextOptions<CustomersDbContext> options) : DbContext(options)
{
    public const string MigrationsHistoryTable = "__CustomersMigrationsHistory";
    public const string SchemaName = "customers";

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(SchemaName);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomersDbContext).Assembly);
    }

    public DbSet<Customer> Customers { get; set; }
}

public class CustomersDbContextFactory : IDesignTimeDbContextFactory<CustomersDbContext>
{
    private const string DESIGN_CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=Cars;Integrated Security=True;TrustServerCertificate=True";

    public CustomersDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<CustomersDbContext>();
        builder.UseSqlServer(DESIGN_CONNECTION_STRING, options => options.MigrationsHistoryTable(CustomersDbContext.MigrationsHistoryTable));
        return new CustomersDbContext(builder.Options);
    }
}