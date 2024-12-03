using Cars.SharedKernel.Sales.ViewModels;
using System.Collections.Generic;

namespace Cars.ReadModel.Sales;

public interface IOffersQuery
{
    IList<OfferListViewModel> GetOffers();
}