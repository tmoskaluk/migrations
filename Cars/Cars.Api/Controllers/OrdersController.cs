using Cars.Customers.Crud;
using Cars.ReadModel.Sales;
using Cars.Sales.Core.Application;
using Cars.Sales.Core.Application.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController(IOrdersApplicationService ordersService, IOrdersQuery ordersQuery, CustomersDbContext customersContext) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(ordersQuery.GetOrders());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(ordersQuery.GetOrder(id));
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateOrderDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.CustomerIdentityNo)) return BadRequest("Missing customer number");

        var customer = customersContext.Customers.FirstOrDefault(c => c.IdentityNo == dto.CustomerIdentityNo);
        if (customer == null) return BadRequest($"Customer {dto.CustomerIdentityNo} doesn't exist");

        var customerDto = new SalesCustomerDto { CustomerId = customer.Id, Name = $"{customer.FirstName} {customer.LastName}" };
        var orderDto = ordersService.PlaceOrder(dto.OfferId, customerDto);

        var location = Url.Action(nameof(Create), new { id = orderDto.OrderId }) ?? $"/{orderDto.OrderId}";
        return Created(location, orderDto);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        ordersService.RejectOrder(id);
        return NoContent();
    }

    [HttpPut("{id}/discount")]
    public IActionResult ApplyDiscount(int id, [FromBody] DiscountDto dto)
    {
        ordersService.ApplyDiscount(id, dto.Discount, dto.Comment);
        return Ok();
    }

    [HttpPut("{id}/confirmation")]
    public IActionResult Confirm(int id, [FromBody] DateTime plannedDeliveryDate)
    {
        ordersService.ConfirmOrder(id, plannedDeliveryDate);
        return Ok();
    }

    [HttpPut("{id}/finalization")]
    public IActionResult Finalize(int id, [FromBody] DateTime receivedDate)
    {
        ordersService.FinalizeOrder(id, receivedDate);
        return Ok();
    }
}

public class CreateOrderDto
{
    public Guid OfferId { get; set; }
    
    public string CustomerIdentityNo { get; set; }
}

public class DiscountDto
{
    public decimal Discount { get; set; }

    public string Comment { get; set; }
}