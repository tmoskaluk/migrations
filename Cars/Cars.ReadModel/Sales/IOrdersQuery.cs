using Cars.SharedKernel.Sales.ViewModels;
using System.Collections.Generic;

namespace Cars.ReadModel.Sales;

public interface IOrdersQuery
{
    OrderListViewModel GetOrder(int id);

    IList<OrderListViewModel> GetOrders();
}