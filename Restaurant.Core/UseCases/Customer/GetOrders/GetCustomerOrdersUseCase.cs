using Restaurant.Core.Dto;
using Restaurant.Core.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Customer.GetOrders;
public class GetCustomerOrdersUseCase
{
	private readonly ICustomerRepository _customerRepository;

	public GetCustomerOrdersUseCase(ICustomerRepository customerRepository)
	{
		_customerRepository = customerRepository;
	}

	public async Task<Result<IList<OrderDto>>> HandleAsync(Guid customerId)
	{
		var customer = await _customerRepository.GetCustomerOrdersAsync(customerId);

		if (customer is null)
		{
			return new() { StatusCode = HttpStatusCode.NotFound, Message = "Not found customer" };
		}

		return new () { StatusCode = HttpStatusCode.OK, Message = "Get customer orders", Data = customer.Orders };
	}
}
