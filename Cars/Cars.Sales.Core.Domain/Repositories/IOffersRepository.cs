using Cars.Sales.Core.Domain.Entities;
using System;

namespace Cars.Sales.Core.Domain.Repositories;

public interface IOffersRepository
{
    Offer Get(Guid id);
        
    void Add(Offer offer);

    void Remove(Offer offer);

    void RemoveExpiredOffers();
}