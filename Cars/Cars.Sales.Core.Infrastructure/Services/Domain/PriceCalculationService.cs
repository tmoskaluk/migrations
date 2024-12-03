using Cars.Sales.Core.Domain.Services;
using Cars.Sales.Core.Domain.ValueObjects;
using System;

namespace Cars.Sales.Core.Infrastructure.Services.Domain;

public class PriceCalculationService : IPriceCalculationService
{
    public decimal CalculatePrice(CarConfiguration carConfiguration)
    {
        //in real life here we can call external service responsible for the price calculation

        return new Random().Next(50000, 200000);
    }
}