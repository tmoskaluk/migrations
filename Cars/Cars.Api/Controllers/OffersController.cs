﻿using Cars.ReadModel.Sales;
using Cars.Sales.Core.Application;
using Cars.Sales.Core.Application.DataTransferObjects;
using Cars.SharedKernel.Sales.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OffersController(IOffersApplicationService offersService, IOffersQuery offersQuery) : ControllerBase
{
    [HttpGet]
    public IEnumerable<OfferListViewModel> Get()
    {
        return offersQuery.GetOffers();
    }

    [HttpPost]
    public IActionResult Post([FromBody] CarConfigurationDto dto)
    {
        if (dto == null) return BadRequest();
        var offer = offersService.CreateOffer(dto);
        return Ok(offer.Id);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        offersService.DeleteOffer(id);
        return Ok();
    }
}