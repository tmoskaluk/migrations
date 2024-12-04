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
    public IActionResult Create([FromBody] Customer value)
    {
        var exists = context.Customers.Any(x => x.IdentityNo == value.IdentityNo);
        if (exists) throw new ArgumentException("Customer with this identity number already exists");

        var customer = context.Customers.Add(value);
        context.SaveChanges();

        var location = Url.Action(nameof(Create), new { id = customer.Entity.Id }) ?? $"/{customer.Entity.Id}";
        return Created(location, customer.Entity.Id);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Customer value)
    {
        var customer = context.Customers.FirstOrDefault(x => x.Id == id);
        if (customer == null) throw new ArgumentException("Invalid customer identifier");

        var exists = context.Customers.Any(x => x.Id != customer.Id && x.IdentityNo == value.IdentityNo);
        if (exists) throw new ArgumentException("Customer with this identity number already exists");

        customer.IdentityNo = value.IdentityNo;
        customer.FirstName = value.FirstName;
        customer.LastName = value.LastName;
        customer.Phone = value.Phone;
        context.SaveChanges();

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var customer = context.Customers.FirstOrDefault(x => x.Id == id);
        if (customer == null) throw new ArgumentException("Invalid customer identifier");

        context.Remove(customer);
        context.SaveChanges();
        return NoContent();
    }
}