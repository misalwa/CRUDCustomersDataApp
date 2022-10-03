using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Shared.Models;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly CustomersDbContext _customersDbContext;

    public CustomersController(CustomersDbContext customersDbContext)
    {
        _customersDbContext = customersDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomers()
    {
        return Ok(await _customersDbContext.Customers.ToListAsync());
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetCustomer([FromRoute] Guid id)
    {
        var customer = await _customersDbContext.Customers.FindAsync(id);
        
        if (customer == null)
        {
            return NotFound();
        }

        return Ok(customer);
    }


    [HttpPost]
    public async Task<IActionResult> AddCustomer(AddCustomerRequest addCustomerRequest)
    {
        var customer = new Customer()
        {
            Id = Guid.NewGuid(),
            FirstName = addCustomerRequest.FirstName,
            LastName = addCustomerRequest.LastName,
            Email = addCustomerRequest.Email,
            Phone = addCustomerRequest.Phone,
            Date = DateTime.Now,
        };
        
        await _customersDbContext.Customers.AddAsync(customer);
        await _customersDbContext.SaveChangesAsync();

        return Ok(customer);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateCustomer([FromRoute] Guid id, UpdateCustomerRequest updateCustomerRequest)
    {
        var customer =await _customersDbContext.Customers.FindAsync(id);

        if (customer != null)
        {
            customer.FirstName = updateCustomerRequest.FirstName;
            customer.LastName = updateCustomerRequest.LastName;
            customer.Email = updateCustomerRequest.Email;
            customer.Phone = updateCustomerRequest.Phone;

            await _customersDbContext.SaveChangesAsync();
            return Ok(customer);
        }

        return NotFound();
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteCustomer([FromRoute] Guid id)
    {
        var customer = await _customersDbContext.Customers.FindAsync(id);

        if (customer != null)
        {
            _customersDbContext.Customers.Remove(customer);
            await _customersDbContext.SaveChangesAsync();
            return Ok(customer);
        }

        return NotFound();
    }
}
