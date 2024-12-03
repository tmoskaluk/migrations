using Microsoft.EntityFrameworkCore;

namespace Cars.Core.Base.UnitOfWork;

public abstract class EntityFrameworkUnitOfWork<TContext>(TContext context) where TContext : DbContext
{
    protected TContext Context { get; } = context;

    public virtual void Commit()
    {
        Context.SaveChanges();
    }
}