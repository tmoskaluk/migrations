using Cars.ReadModel.Sales;
using Cars.Sales.Core.Application;
using Cars.SharedKernel.Sales.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController(IOrdersApplicationService ordersService, IOrdersQuery ordersQuery) : ControllerBase
{
    // GET: api/<OrderController>
    [HttpGet]
    public IEnumerable<OrderListViewModel> Get()
    {
        return ordersQuery.GetOrders();
    }

    // GET api/<OrderController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<OrderController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
        //ordersService.PlaceOrder();
        //return Ok();
    }

    // PUT api/<OrderController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<OrderController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}