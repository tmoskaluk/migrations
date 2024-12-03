using Cars.Sales.Core.Domain.ValueObjects;

namespace Cars.Sales.Core.Domain.Services;

public interface IPriceCalculationService
{
    decimal CalculatePrice(CarConfiguration carConfiguration);
}