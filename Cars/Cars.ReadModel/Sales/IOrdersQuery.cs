using Cars.SharedKernel.Sales.ViewModels;
using System.Collections.Generic;

namespace Cars.ReadModel.Sales;

public interface IOrdersQuery
{
    IList<OrderListViewModel> GetOrders();
}