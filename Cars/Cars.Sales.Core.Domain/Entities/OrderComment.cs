using System;

namespace Cars.Sales.Core.Domain.Entities;

public class OrderComment
{
    private OrderComment()
    {
    }

    public OrderComment(string comment, Order order)
    {
        if (string.IsNullOrWhiteSpace(comment)) throw new ArgumentException("Can't create null or whitespace order's comment");

        Comment = comment;
        CreationDate = DateTime.Now;
        Order = order;
    }

    public int Id { get; private set; }

    public DateTime CreationDate { get; private set; }

    public string Comment { get; private set; }

    public Order Order { get; private set; }
}