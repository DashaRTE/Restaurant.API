using Microsoft.AspNetCore.Mvc;
using Restaurant.API.Requests;
using Restaurant.Core;
using Restaurant.Core.UseCases;
using Restaurant.Core.UseCases.Customer;
using Restaurant.Core.UseCases.Customer.Delete;
using Restaurant.Core.UseCases.Customer.Edit;
using Restaurant.Core.UseCases.Customer.Get;
using Restaurant.Core.UseCases.Customer.GetById;
using Restaurant.Core.UseCases.Customer.GetOrders;
using Restaurant.Infrastucture.Entities;
using System.ComponentModel.DataAnnotations;

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
	private readonly GetCustomerByIdUseCase _getCustomerByIdUseCase;
	private readonly GetCustomerOrdersUseCase _getCustomerOrdersUseCase;

	public CustomerController(
		CreateCustomerUseCase createCustomerUseCase, 
		GetCustomerUseCase getCustomerUseCase, 
		EditCustomerUseCase editCustomerUseCase, 
		DeleteCustomerUseCase deleteCustomerUseCase, 
		GetCustomerByIdUseCase getCustomerByIdUseCase, 
		GetCustomerOrdersUseCase getCustomerOrdersUseCase)
	{
		_createCustomerUseCase = createCustomerUseCase;
		_getCustomerUseCase = getCustomerUseCase;
		_editCustomerUseCase = editCustomerUseCase;
		_deleteCustomerUseCase = deleteCustomerUseCase;
		_getCustomerByIdUseCase = getCustomerByIdUseCase;
		_getCustomerOrdersUseCase = getCustomerOrdersUseCase;
	}

	[HttpGet, Route("get")]
	public async Task<Result<List<Customer>>> GetCustomersAsync() => await _getCustomerUseCase.HandleAsync();

	[HttpPost, Route("create")]
	public async Task<Result> CreateCustomerAsync([Required, FromBody] CreateUserRequest request)
	{
		var result = await _createCustomerUseCase.HandleAsync(new(request.Name, request.Email, request.Password));

		return result;
	}

	[HttpPut, Route("edit")]
	public async Task<Result> EditCustomerAsync([Required, FromBody] Requests.EditCustomerRequest request)
	{
		var result = await _editCustomerUseCase.HandleAsync(new(request.CustomerId, request.Name, request.Email, request.Password));

		return result;
	}

	[HttpDelete, Route("delete/{customerId}")]
	public async Task<Result> DeleteCustomerAsync([Required] Guid customerId)
	{
		var result = await _deleteCustomerUseCase.HandleAsync(customerId);

		return result;
	}

	[HttpGet, Route("get/{customerId}")]
	public async Task<Result<Customer>> GetCustomerByIdAsync([Required] Guid customerId)
	{
		var result = await _getCustomerByIdUseCase.HandleAsync(customerId);

		return result;
	}

	[HttpGet, Route("get/orders/{customerId}")]
	public async Task<Result<List<Order>>> GetCustomerOrdersAsync([Required] Guid customerId)
	{
		var result = await _getCustomerOrdersUseCase.HandleAsync(customerId);

		return result;
	}
}