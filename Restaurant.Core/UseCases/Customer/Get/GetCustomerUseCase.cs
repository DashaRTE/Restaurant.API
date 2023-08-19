using Restaurant.Infrastucture.Repositories.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases;
public class GetCustomerUseCase
{
	private readonly ICustomerRepository _customerRepository;

	public GetCustomerUseCase(ICustomerRepository customerRepository)
	{
		_customerRepository = customerRepository;
	}

	public async Task<Result<List<Infrastucture.Entities.Customer>>> HandleAsync()
	{
		var result = await _customerRepository.GetCustomersAsync();

		return new () { StatusCode = HttpStatusCode.OK, Message = "Get customers", Data = result };
	}
}
