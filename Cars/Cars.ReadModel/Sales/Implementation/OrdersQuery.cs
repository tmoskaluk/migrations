using Cars.SharedKernel.Sales.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Cars.Sales.Core.Infrastructure;

namespace Cars.ReadModel.Sales.Implementation;

public class OrdersQuery(SalesDbContext context) : IOrdersQuery
{
    public OrderListViewModel GetOrder(int id)
    {
        return context.OrderListView.FirstOrDefault(x => x.Id == id);
    }

    public IList<OrderListViewModel> GetOrders()
    {
        return context.OrderListView.OrderBy(x => x.CreationDate).ToList();
    }
}