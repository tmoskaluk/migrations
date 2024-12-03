using Cars.SharedKernel.Enums;
using System;

namespace Cars.SharedKernel.Sales.ViewModels;

public class OrderListViewModel
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string CustomerName { get; set; }

    public DateTime CreationDate { get; set; }

    public decimal Price { get; set; }

    public decimal Discount { get; set; }

    public OrderStatus Status { get; set; }

    public int Comments { get; set; }
        
}