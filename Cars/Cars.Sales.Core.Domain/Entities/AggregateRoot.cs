namespace Cars.Sales.Core.Domain.Entities;

public abstract class AggregateRoot<T>
{
    public T Id { get; protected set; }
}