using System.Reflection;
using Cars.Sales.Core.Domain.Entities;
using Cars.Sales.Core.Infrastructure.Mappings;
using Cars.SharedKernel.Sales.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Cars.Sales.Core.Infrastructure;

public class SalesDbContext(DbContextOptions<SalesDbContext> options) : DbContext(options)
{
    public const string MigrationsHistoryTable = "__SalesMigrationsHistory";
    internal const string DbMoneyType = "money";
    public const string SchemaName = "sales";

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(SchemaName);

        modelBuilder.ApplyConfiguration(new OfferMap());
        modelBuilder.ApplyConfiguration(new OrderMap());
        modelBuilder.ApplyConfiguration(new OrderCommentMap());

        modelBuilder.Entity<OrderListViewModel>(e =>
        {
            e.HasNoKey();
            e.ToView("OrderListView");
        });
    }

    public DbSet<Offer> Offers { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderListViewModel> OrderListView { get; set; }
}

public class SalesDbContextFactory : IDesignTimeDbContextFactory<SalesDbContext>
{
    private const string DESIGN_CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=Cars;Integrated Security=True;TrustServerCertificate=True";

    public SalesDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<SalesDbContext>();
        builder.UseSqlServer(DESIGN_CONNECTION_STRING, options => options.MigrationsHistoryTable(SalesDbContext.MigrationsHistoryTable));
        return new SalesDbContext(builder.Options);
    }
}