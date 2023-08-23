using Restaurant.Core.Dto;
using Restaurant.Core.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases;

public class GetCustomerUseCase
{
	private readonly ICustomerRepository _customerRepository;

	public GetCustomerUseCase(ICustomerRepository customerRepository)
	{
		_customerRepository = customerRepository;
	}

	public async Task<Result<IList<CustomerDto>>> HandleAsync()
	{
		var customers = await _customerRepository.GetCustomersAsync();

		return new()
		{
			StatusCode = HttpStatusCode.OK,
			Message = "Get customers",
			Data = customers
		};
	}
}