using Restaurant.Infrastucture.Repositories.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Customer.GetOrders;
public class GetCustomerOrdersUseCase
{
	private readonly ICustomerRepository _customerRepository;

	public GetCustomerOrdersUseCase(ICustomerRepository customerRepository)
	{
		_customerRepository = customerRepository;
	}

	public async Task<Result<List<Infrastucture.Entities.Order>>> HandleAsync(Guid customerId)
	{
		var result = await _customerRepository.GetCustomerOrdersAsync(customerId);

		if (result is null)
		{
			return new() { StatusCode = HttpStatusCode.NotFound, Message = "Not found" };
		}

		var orders = result.Orders.ToList();

		return new () { StatusCode = HttpStatusCode.OK, Message = "Get customer orders", Data = orders };
	}
}
