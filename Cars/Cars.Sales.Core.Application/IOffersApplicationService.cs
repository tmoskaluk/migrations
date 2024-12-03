using System;
using Cars.Sales.Core.Application.DataTransferObjects;

namespace Cars.Sales.Core.Application;

public interface IOffersApplicationService
{
    OfferDto CreateOffer(CarConfigurationDto carConfiguration);

    void DeleteOffer(Guid offerId);
        
    void DeleteExpiredOffers();
}