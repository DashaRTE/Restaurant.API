using Restaurant.Infrastucture.Repositories.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Customer.GetById;
public class GetCustomerByIdUseCase
{
	private readonly ICustomerRepository _customerRepository;

	public GetCustomerByIdUseCase(ICustomerRepository customerRepository)
	{
		_customerRepository = customerRepository;
	}

	public async Task<Result<Infrastucture.Entities.Customer>> HandleAsync(Guid customerId)
	{
		var result = await _customerRepository.GetCustomerByIdAsync(customerId);

		if (result is null)
		{
			return new() { StatusCode = HttpStatusCode.NotFound, Message = "Not found" };
		}

		return new () { StatusCode = HttpStatusCode.OK, Message = "Get customer by id", Data = result };
	}
}
