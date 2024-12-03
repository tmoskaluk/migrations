using Cars.Sales.Core.Domain.ValueObjects;
using System;

namespace Cars.Sales.Core.Domain.Entities;

public class Offer : AggregateRoot<Guid>
{
    private const int DEFAULT_EXPIRATION_TIME_IN_MONTHS = 3;

    private Offer()
    {
    }

    public Offer(CarConfiguration configuration, decimal price)
    {
        if (configuration == null) throw new ArgumentException(nameof(configuration));

        Id = Guid.NewGuid();
        Configuration = configuration;
        TotalPrice = price;
        CreationDate = DateTime.Now;
        ExpirationDate = CreationDate.AddMonths(DEFAULT_EXPIRATION_TIME_IN_MONTHS);
    }

    public DateTime CreationDate { get; private set; }

    public DateTime ExpirationDate { get; private set; }
        
    public decimal TotalPrice { get; private set; }

    public CarConfiguration Configuration { get; private set; }

    public void ChangeExpirationDate(DateTime expirationDate)
    {
        ExpirationDate = expirationDate;
    }
}