namespace Cars.Sales.Core.Domain;

public interface ISalesUnitOfWork
{
    void Commit();
}