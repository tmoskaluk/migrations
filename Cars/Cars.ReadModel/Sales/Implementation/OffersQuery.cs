using System.Collections.Generic;
using System.Linq;
using Cars.Sales.Core.Infrastructure;
using Cars.SharedKernel.Sales.ViewModels;

namespace Cars.ReadModel.Sales.Implementation;

public class OffersQuery(SalesDbContext context) : IOffersQuery
{
    public IList<OfferListViewModel> GetOffers()
    {
        return context.Offers.Select(o => new OfferListViewModel
        {
            OfferId = o.Id,
            CreationDate = o.CreationDate,
            TotalPrice = o.TotalPrice,
            Model = o.Configuration.Model
        }).OrderBy(o => o.CreationDate).ToList();
    }
}