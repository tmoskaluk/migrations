using System;

namespace Cars.SharedKernel.Sales.ViewModels;

public class OfferListViewModel
{
    public Guid OfferId { get; set; }

    public DateTime CreationDate { get; set; }

    public decimal TotalPrice { get; set; }

    public string Model { get; set; }
}