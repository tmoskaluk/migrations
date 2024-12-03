using System;
using Cars.SharedKernel.Sales.ViewModels;
using System.Collections.Generic;
using Cars.Sales.Core.Infrastructure;

namespace Cars.ReadModel.Sales.Implementation;

public class OrdersQuery(SalesDbContext context) : IOrdersQuery
{
    public IList<OrderListViewModel> GetOrders()
    {
        throw new NotImplementedException();
        
        //return context.OrderListView.OrderBy(x => x.CreationDate).ToList();
    }
}