using Restaurant.Infrastucture.Repositories.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Customer;
public class CreateCustomerUseCase
{
	private readonly ICustomerRepository _customerRepository;

	public CreateCustomerUseCase(ICustomerRepository customerRepository)
	{
		_customerRepository = customerRepository;
	}

	public async Task<Result> HandleAsync(CreateCustomerRequest request)
	{
		await _customerRepository.CreateCustomerAsync(request.Email, request.Name, request.Password);

		return new Result() { StatusCode = HttpStatusCode.Created, Message = "Create customer" };
	}
}
