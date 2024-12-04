using Cars.Sales.Core.Domain.ValueObjects;
using Cars.SharedKernel.Enums;
using System;
using System.Collections.Generic;

namespace Cars.Sales.Core.Domain.Entities;

public class Order : AggregateRoot<int>
{
    private const decimal MAXIMUM_PERCENT_DISCOUNT = 0.4M;
    private readonly List<OrderComment> comments = new();
        
    public static Order Create(Offer offer, Customer customer)
    {
        if (offer.ExpirationDate < DateTime.Now) throw new Exception("Can't create order from expired offer");

        return Create(offer.Configuration, offer.TotalPrice, customer);
    }

    public static Order Create(CarConfiguration configuration, decimal price, Customer customer)
    {
        return new()
        {
            Configuration = configuration,
            Customer = customer,
            OriginalPrice = price,
            Price = price,
            CreationDate = DateTime.Now,
            Status = OrderStatus.Created
        };
    }

    #region Properties

    public CarConfiguration Configuration { get; private set; }

    public Customer Customer { get; private set; }

    public DateTime CreationDate { get; private set; }

    public DateTime? PlannedDeliveryDate { get; private set; }

    public DateTime? ReceivedDate { get; private set; }

    public decimal OriginalPrice { get; private init; }

    public decimal Price { get; private set; }

    public OrderStatus Status { get; private set; }

    public IReadOnlyCollection<OrderComment> Comments => comments.AsReadOnly();

    public decimal Discount => OriginalPrice - Price;

    #endregion

    public void ApplyDiscount(decimal discount)
    {
        if (discount <= 0) throw new ArgumentException("Wrong discount", nameof(discount));
        if (discount > OriginalPrice * MAXIMUM_PERCENT_DISCOUNT) throw new ArgumentException("The maximum discount limit is exceeded");
        if (Status != OrderStatus.Created) throw new ArgumentException($"Applying discount is available only for order with {OrderStatus.Created} status");

        Price = OriginalPrice - discount;
    }

    public void Confirm(DateTime plannedDeliveryDate)
    {
        if (plannedDeliveryDate <= DateTime.Now) throw new ArgumentException("Can't set the past date for the order");
        if (Status != OrderStatus.Created) throw new ArgumentException($"Confirmation is available only for order with {OrderStatus.Created} status");

        Status = OrderStatus.Confirmed;
        PlannedDeliveryDate = plannedDeliveryDate;
    }

    public void UpdatePlannedDeliveryDate(DateTime plannedDeliveryDate)
    {
        if (Status != OrderStatus.Confirmed) throw new ArgumentException("Can't define planned delivery date for closed or not confirmed orders");
        if (plannedDeliveryDate <= DateTime.Now) throw new ArgumentException("Can't set the past date for the order");

        PlannedDeliveryDate = plannedDeliveryDate;
    }

    public void Finalize(DateTime receivedDate)
    {
        if (Status != OrderStatus.Confirmed) throw new ArgumentException("Can't finalize order without confirmation");

        ReceivedDate = receivedDate;
        Status = OrderStatus.Finalized;
    }

    public void AddComment(string comment)
    {
        this.comments.Add(new OrderComment(comment, this));
    }

    public void Reject()
    {
        if (Status == OrderStatus.Finalized) throw new ArgumentException("Can't reject closed order");

        Status = OrderStatus.Rejected;
    }
}