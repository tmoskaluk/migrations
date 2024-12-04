using System;
using Cars.Sales.Core.Domain.Entities;
using Cars.SharedKernel.Enums;

namespace Cars.Customers.Crud.Models;

public class Customer : AggregateRoot<int>
{
    public const int IdentityNoMaxLength = 64;
    public const int PhoneMaxLength = 20;
    public const int NameMaxLength = 100;

    public Customer(CustomerType customerType, string identityNo, string firstName, string lastName, string phone)
    {
        Validate(identityNo, firstName, lastName, phone);

        CustomerType = customerType;
        IdentityNo = identityNo;
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
    }

    public CustomerType CustomerType { get; set; }

    public string IdentityNo { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Phone { get; set; }

    private static void Validate(string identityNo, string firstName, string lastName, string phone)
    {
        if (string.IsNullOrEmpty(identityNo)) throw new ArgumentException(nameof(identityNo));
        if (string.IsNullOrEmpty(firstName)) throw new ArgumentException(nameof(firstName));
        if (string.IsNullOrEmpty(lastName)) throw new ArgumentException(nameof(lastName));

        if (identityNo.Length > IdentityNoMaxLength) throw new ArgumentException(nameof(identityNo));
        if (firstName.Length > NameMaxLength) throw new ArgumentException(nameof(firstName));
        if (lastName.Length > NameMaxLength) throw new ArgumentException(nameof(lastName));
        if (phone?.Length > PhoneMaxLength) throw new ArgumentException(nameof(phone));
    }
}