using System;
using Cars.Customers.Crud;
using Cars.Sales.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cars.Dependency;

public class CarsStartup
{
    public static void EnsureDatabaseStructure(IServiceProvider services)
    {
        using (var context = services.CreateScope().ServiceProvider.GetRequiredService<CustomersDbContext>())
        {
            context.Database.Migrate();
        }

        using (var context = services.CreateScope().ServiceProvider.GetRequiredService<SalesDbContext>())
        {
            context.Database.Migrate();
        }
    }
}