using Microsoft.AspNetCore.Mvc;
using Restaurant.API.Requests;
using Restaurant.API.Responses;
using Restaurant.Infrastucture.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.API.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/customer")]
public class CustomerController : ControllerBase
{
	private readonly ICustomerRepository _customerRepository;

	public CustomerController(ICustomerRepository customerRepository)
	{
		_customerRepository = customerRepository;
	}

	[HttpGet, Route("get")]
	public async Task<IActionResult> GetCustomersAsync()
	{
		var customers = await _customerRepository.GetCustomersAsync();
		return Ok(customers);
	}

	[HttpPost, Route("create")]
	public async Task<IActionResult> CreateCustomerAsync([Required, FromBody] CreateUserRequest Request)
	{
		var customer = await _customerRepository.CreateCustomerAsync(Request.Email, Request.Name, Request.Password);
		return Ok(customer);
	}

	[HttpPut, Route("edit")]
	public async Task<IActionResult> EditCustomerAsync([Required, FromBody] EditCustomerRequest Request)
	{
		var customer =
			await _customerRepository.EditCustomerAsync(Request.CustomerId, Request.Email, Request.Name,
				Request.Password);
		return Ok(customer);
	}

	[HttpDelete, Route("delete/{customerId}")]
	public async Task<IActionResult> DeleteCustomerAsync([Required] Guid customerId)
	{
		await _customerRepository.DeleteCustomerAsync(customerId);
		return Ok();
	}

	[HttpGet, Route("get/{customerId}")]
	public async Task<IActionResult> GetCustomerByIdAsync([Required] Guid customerId)
	{
		var customer = await _customerRepository.GetCustomerByIdAsync(customerId);
		if (customer is null)
		{
			return NotFound();
		}

		return Ok(customer);
	}

	[HttpGet, Route("get/orders/{customerId}")]
	public async Task<IActionResult> GetCustomerOrdersAsync([Required] Guid customerId)
	{
		var customer = await _customerRepository.GetCustomerOrdersAsync(customerId);

		if (customer?.Orders is null)
		{
			return NotFound();
		}

		return Ok(new CustomerOrdersResponse(customer.Id, customer.Email, customer.Name, customer.Password,
			customer.Orders.Select(order => new CustomerOrderResponse(order.Number, order.Price)).ToList()));
	}
}