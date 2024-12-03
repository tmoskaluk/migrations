using Cars.Customers.Crud;
using Cars.Customers.Crud.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController(CustomersDbContext context) : ControllerBase
{
    [HttpGet]
    public IEnumerable<Customer> Get()
    {
        return context.Customers.ToList();
    }

    [HttpGet("{id}")]
    public Customer Get(int id)
    {
        return context.Customers.FirstOrDefault(x => x.Id == id);
    }

    [HttpPost]
    public void Post([FromBody] Customer value)
    {
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}