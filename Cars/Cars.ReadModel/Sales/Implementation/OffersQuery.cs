using System.Collections.Generic;
using System.Linq;
using Cars.Sales.Core.Infrastructure;
using Cars.SharedKernel.Sales.ViewModels;

namespace Cars.ReadModel.Sales.Implementation;

public class OffersQuery : IOffersQuery
{
    private readonly SalesDbContext context;

    public OffersQuery(SalesDbContext context)
    {
        this.context = context;
    }

    public IList<OfferListViewModel> GetOffers()
    {
        return this.context.Offers.Select(o => new OfferListViewModel { OfferId = o.Id, CreationDate = o.CreationDate, TotalPrice = o.TotalPrice })
            .OrderBy(o => o.CreationDate)
            .ToList();
    }
}