using Restaurant.Core.Dto;
using Restaurant.Core.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Customer.GetById;
public class GetCustomerByIdUseCase
{
	private readonly ICustomerRepository _customerRepository;

	public GetCustomerByIdUseCase(ICustomerRepository customerRepository)
	{
		_customerRepository = customerRepository;
	}

	public async Task<Result<CustomerDto>> HandleAsync(Guid customerId)
	{
		var customer = await _customerRepository.GetCustomerByIdAsync(customerId);

		if (customer is null)
		{
			return new() { StatusCode = HttpStatusCode.NotFound, Message = "Not found" };
		}

		return new () { StatusCode = HttpStatusCode.OK, Message = "Get customer by id", Data = customer };
	}
}
