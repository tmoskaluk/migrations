using Cars.Sales.Core.Application;
using Cars.Sales.Core.Application.DataTransferObjects;
using Cars.Sales.Core.Domain;
using Cars.Sales.Core.Domain.Entities;
using Cars.Sales.Core.Domain.Repositories;
using Cars.Sales.Core.Domain.Services;
using Cars.Sales.Core.Domain.ValueObjects;
using Cars.SharedKernel;
using System;

namespace Cars.Sales.Core.Infrastructure.Services.Application;

public class OffersApplicationService(IAppLogger logger, ISalesUnitOfWork unitOfWork, IOffersRepository offersRepository, IPriceCalculationService priceService) 
    : IOffersApplicationService
{
    public OfferDto CreateOffer(CarConfigurationDto dto)
    {
        var carConfiguration = new CarConfiguration(dto.Model, new Engine(dto.EngineCode, dto.EngineType, dto.EngineCapacity), dto.Version);
        var price = priceService.CalculatePrice(carConfiguration);
        var offer = new Offer(carConfiguration, price);
        offersRepository.Add(offer);
        unitOfWork.Commit();

        logger.Info($"Offer created [Id = {offer.Id}]");
        return new OfferDto(offer);
    }

    public void DeleteOffer(Guid offerId)
    {
        var offer = offersRepository.Get(offerId);
        offersRepository.Remove(offer);
        unitOfWork.Commit();
        logger.Info($"Offer {offerId} has been deleted");
    }

    public void DeleteExpiredOffers()
    {
        var expirationDate = DateTime.Now;
        offersRepository.RemoveExpiredOffers(expirationDate);
        unitOfWork.Commit();
        logger.Info($"Offers with expiration date before {expirationDate} were deleted");
    }
}