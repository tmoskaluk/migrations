using Cars.Sales.Core.Domain.Entities;
using Cars.Sales.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Cars.Sales.Core.Infrastructure.Repositories;

public class OrdersRepository(SalesDbContext context) : AbstractRepository<Order, int, SalesDbContext>(context), IOrdersRepository
{
    public override Order Get(int id)
    {
        return Context.Orders.Include(x => x.Comments).FirstOrDefault(x => x.Id == id);
    }
}