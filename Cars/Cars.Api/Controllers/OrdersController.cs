using Cars.Customers.Crud;
using Cars.ReadModel.Sales;
using Cars.Sales.Core.Application;
using Cars.Sales.Core.Application.DataTransferObjects;
using Cars.SharedKernel.Sales.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController(IOrdersApplicationService ordersService, IOrdersQuery ordersQuery, CustomersDbContext customersContext) : ControllerBase
{
    [HttpGet]
    public IEnumerable<OrderListViewModel> Get()
    {
        return ordersQuery.GetOrders();
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateOfferDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.CustomerIdentityNo)) return BadRequest("Missing customer number");

        var customer = customersContext.Customers.FirstOrDefault(c => c.IdentityNo == dto.CustomerIdentityNo);
        if (customer == null) return BadRequest($"Customer {dto.CustomerIdentityNo} doesn't exist");

        var customerDto = new SalesCustomerDto { CustomerId = customer.Id, Name = $"{customer.FirstName} {customer.LastName}" };
        var orderDto = ordersService.PlaceOrder(dto.Offer, customerDto);
        return Ok(orderDto.OrderId);
    }

    [HttpPut("{id}/discount")]
    public IActionResult Put(int id, [FromBody] DiscountDto dto)
    {
        ordersService.ApplyDiscount(id, dto.Discount, dto.Comment);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        ordersService.Reject(id);
        return Ok(); 
    }
}

public class CreateOfferDto
{
    public OfferDto Offer { get; set; }

    public string CustomerIdentityNo { get; set; }
}

public class DiscountDto
{
    public decimal Discount { get; set; }

    public string Comment { get; set; }
}