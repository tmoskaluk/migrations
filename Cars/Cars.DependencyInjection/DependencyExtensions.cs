using Cars.Customers.Crud;
using Cars.ReadModel.Sales;
using Cars.ReadModel.Sales.Implementation;
using Cars.Sales.Core.Application;
using Cars.Sales.Core.Domain;
using Cars.Sales.Core.Domain.Repositories;
using Cars.Sales.Core.Domain.Services;
using Cars.Sales.Core.Infrastructure;
using Cars.Sales.Core.Infrastructure.Repositories;
using Cars.Sales.Core.Infrastructure.Services.Application;
using Cars.Sales.Core.Infrastructure.Services.Domain;
using Cars.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cars.Dependency;

public static class DependencyExtensions
{
    /// <summary>
    /// Add dependencies related to Cars project
    /// </summary>
    public static void AddCarsProject(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IAppLogger, AppLogger>();
        services.AddTransient<IOffersApplicationService, OffersApplicationService>();
        services.AddTransient<IOrdersApplicationService, OrdersApplicationService>();
        services.AddTransient<IPriceCalculationService, PriceCalculationService>();
        services.AddTransient<IOffersRepository, OffersRepository>();
        services.AddTransient<IOrdersRepository, OrdersRepository>();
        services.AddTransient<IOffersQuery, OffersQuery>();
        services.AddTransient<IOrdersQuery, OrdersQuery>();
        services.AddTransient<ISalesUnitOfWork, SalesUnitOfWork>();

        services.AddDbContext<SalesDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("CarsDb"), c => c.MigrationsHistoryTable(SalesDbContext.MigrationsHistoryTable)));
        services.AddDbContext<CustomersDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("CarsDb"), c => c.MigrationsHistoryTable(CustomersDbContext.MigrationsHistoryTable)));
    }
}