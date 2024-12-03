using Cars.Sales.Core.Domain.Entities;
using Cars.Sales.Core.Domain.Repositories;
using System;
using System.Linq;

namespace Cars.Sales.Core.Infrastructure.Repositories;

public class OffersRepository(SalesDbContext context) : AbstractRepository<Offer, Guid, SalesDbContext>(context), IOffersRepository
{
    public void RemoveExpiredOffers(DateTime expirationDate)
    {
        var expiredOffers = this.Context.Offers.Where(o => o.ExpirationDate < expirationDate);
        this.Context.RemoveRange(expiredOffers);
    }
}