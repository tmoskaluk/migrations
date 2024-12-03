using Cars.Sales.Core.Domain.Entities;

namespace Cars.Sales.Core.Domain.Repositories;

public interface IOrdersRepository
{
    Order Get(int id);

    void Add(Order order);
}