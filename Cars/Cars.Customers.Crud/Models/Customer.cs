using System;
using Cars.Sales.Core.Domain.Entities;
using Cars.SharedKernel.Enums;

namespace Cars.Customers.Crud.Models;

public class Customer : AggregateRoot<int>
{
    public Customer(CustomerType type, string identityNo, string firstName, string lastName, string phone)
    {
        Validate(firstName, lastName, phone);

        Type = type;
        IdentityNo = identityNo;
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
    }

    public CustomerType Type { get; set; }

    public string IdentityNo { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Phone { get; set; }

    private static void Validate(string firstName, string lastName, string phone)
    {
        if (string.IsNullOrEmpty(firstName)) throw new ArgumentException(nameof(firstName));
        if (string.IsNullOrEmpty(lastName)) throw new ArgumentException(nameof(lastName));
        if (phone?.Length > 20) throw new ArgumentException(nameof(phone));
    }
}