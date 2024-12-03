using Cars.Sales.Core.Application;
using Cars.Sales.Core.Application.DataTransferObjects;
using Cars.Sales.Core.Domain;
using Cars.Sales.Core.Domain.Entities;
using Cars.Sales.Core.Domain.Repositories;
using Cars.Sales.Core.Domain.Services;
using Cars.Sales.Core.Domain.ValueObjects;
using Cars.SharedKernel;

namespace Cars.Sales.Core.Infrastructure.Services.Application;

public class OffersApplicationService(IAppLogger logger, ISalesUnitOfWork unitOfWork, IOffersRepository offersRepository, IPriceCalculationService priceService) 
    : IOffersApplicationService
{
    public OfferDto CreateOffer(CarConfigurationDto dto)
    {
        var carConfiguration = new CarConfiguration(dto.Model, new Engine(dto.EngineCode, dto.EngineType, dto.EngineCapacity), dto.GearboxType, dto.Version, dto.Color);
        var price = priceService.CalculatePrice(carConfiguration);
        var offer = new Offer(carConfiguration, price);
        offersRepository.Add(offer);
        unitOfWork.Commit();

        logger.Info($"Offer created [Id = {offer.Id}]");
        return new OfferDto(offer);
    }

    public void DeleteExpiredOffers()
    {
        offersRepository.RemoveExpiredOffers();
        unitOfWork.Commit();
        logger.Info($"Expired offers deleted");
    }
}