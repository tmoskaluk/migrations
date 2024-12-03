using Cars.SharedKernel.Sales.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Cars.Sales.Core.Infrastructure;

namespace Cars.ReadModel.Sales.Implementation;

public class OrdersQuery : IOrdersQuery
{
    private readonly SalesDbContext context;

    public OrdersQuery(SalesDbContext context)
    {
        this.context = context;
    }

    public IList<OrderListViewModel> GetOrders()
    {
        return this.context.OrderListView.OrderBy(x => x.CreationDate).ToList();
    }
}