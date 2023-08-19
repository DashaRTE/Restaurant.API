using Microsoft.AspNetCore.Mvc;
using Restaurant.API.Requests;
using Restaurant.Core;
using Restaurant.Core.UseCases;
using Restaurant.Core.UseCases.Customer;
using Restaurant.Core.UseCases.Customer.Delete;
using Restaurant.Core.UseCases.Customer.Edit;
using System.ComponentModel.DataAnnotations;
using EditCustomerRequest = Restaurant.API.Requests.EditCustomerRequest;

namespace Restaurant.API.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/customer")]
public class CustomerController : ControllerBase
{
	private readonly CreateCustomerUseCase _createCustomerUseCase;
	private readonly GetCustomerUseCase _getCustomerUseCase;
	private readonly EditCustomerUseCase _editCustomerUseCase;
	private readonly DeleteCustomerUseCase _deleteCustomerUseCase;

	public CustomerController(CreateCustomerUseCase createCustomerUseCase, GetCustomerUseCase getCustomerUseCase, EditCustomerUseCase editCustomerUseCase, DeleteCustomerUseCase deleteCustomerUseCase)
	{
		_createCustomerUseCase = createCustomerUseCase;
		_getCustomerUseCase = getCustomerUseCase;
		_editCustomerUseCase = editCustomerUseCase;
		_deleteCustomerUseCase = deleteCustomerUseCase;
	}

	[HttpGet, Route("get")]
	public async Task<Result<List<Infrastucture.Entities.Customer>>> GetCustomersAsync()
	{
		return await _getCustomerUseCase.HandleAsync();
	}

	[HttpPost, Route("create")]
	public async Task<Result> CreateCustomerAsync([Required, FromBody] CreateUserRequest Request)
	{
		var result = await _createCustomerUseCase.HandleAsync(new(Request.Email, Request.Name, Request.Password));
		
		return result; 
	}

	[HttpPut, Route("edit")]
	public async Task<Result> EditCustomerAsync([Required, FromBody] EditCustomerRequest Request)
	{
		var result = await _editCustomerUseCase.HandleAsync(new(Request.CustomerId, Request.Email, Request.Name, Request.Password));

		return result;
	}

	[HttpDelete, Route("delete/{customerId}")]
	public async Task<Result> DeleteCustomerAsync([Required] Guid customerId)
	{
		var result = await _deleteCustomerUseCase.HandleAsync(customerId);
		return result;
	}

	//[HttpGet, Route("get/{customerId}")]
	//public async Task<IActionResult> GetCustomerByIdAsync([Required] Guid customerId)
	//{
	//	var customer = await _customerRepository.GetCustomerByIdAsync(customerId);
	//	if (customer is null)
	//	{
	//		return NotFound();
	//	}

	//	return Ok(customer);
	//}

	//[HttpGet, Route("get/orders/{customerId}")]
	//public async Task<IActionResult> GetCustomerOrdersAsync([Required] Guid customerId)
	//{
	//	var customer = await _customerRepository.GetCustomerOrdersAsync(customerId);

	//	if (customer?.Orders is null)
	//	{
	//		return NotFound();
	//	}

	//	return Ok(new CustomerOrdersResponse(customer.Id, customer.Email, customer.Name, customer.Password,
	//		customer.Orders.Select(order => new CustomerOrderResponse(order.Number, order.Price)).ToList()));
	//}
}