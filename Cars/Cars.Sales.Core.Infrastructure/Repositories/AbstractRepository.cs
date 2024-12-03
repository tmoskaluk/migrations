using Cars.Sales.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cars.Sales.Core.Infrastructure.Repositories;

public abstract class AbstractRepository<TEntity, TKey, TContext>(TContext context)
    where TEntity : AggregateRoot<TKey>
    where TContext : DbContext
{
    protected TContext Context { get; } = context;

    public virtual TEntity Get(TKey id)
    {
        return Context.Set<TEntity>().Find(id);
    }

    public virtual void Add(TEntity entity)
    {
        Context.Set<TEntity>().Add(entity);
    }

    public virtual void Remove(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }
}