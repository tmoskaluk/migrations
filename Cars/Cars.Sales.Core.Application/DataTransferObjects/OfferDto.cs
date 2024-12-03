using Cars.Sales.Core.Domain.Entities;
using System;

namespace Cars.Sales.Core.Application.DataTransferObjects;

public class OfferDto
{
    public OfferDto(Offer offer)
    {
        Id = offer.Id;
        CreationDate = offer.CreationDate;
        ExpirationDate = offer.ExpirationDate;
        TotalPrice = offer.TotalPrice;

        var c = offer.Configuration;
        Configuration = new CarConfigurationDto
        {
            Model = c.Model,
            EngineType = c.Engine.Type,
            EngineCode = c.Engine.Code,
            EngineCapacity = c.Engine.Capacity,
            Version = c.Version
        };
    }

    public Guid Id { get; private set; }

    public DateTime CreationDate { get; private set; }

    public DateTime ExpirationDate { get; private set; }

    public CarConfigurationDto Configuration { get; private set; }

    public decimal TotalPrice { get; private set; }
}