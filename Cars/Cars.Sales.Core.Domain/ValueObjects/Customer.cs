using System;

namespace Cars.Sales.Core.Domain.ValueObjects;

public class Customer : ValueObject<Customer>
{
    public Customer(int customerId, string name)
    {
        if (customerId == default(int)) throw new ArgumentException(nameof(customerId));

        CustomerId = customerId;
        Name = name;
    }

    public int CustomerId { get; private set; }

    public string Name { get; private set; }
}