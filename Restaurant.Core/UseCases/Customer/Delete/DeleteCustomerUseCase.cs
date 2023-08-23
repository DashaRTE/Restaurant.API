using Restaurant.Core.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Customer.Delete;
public class DeleteCustomerUseCase
{
	private readonly ICustomerRepository _customerRepository;

	public DeleteCustomerUseCase(ICustomerRepository customerRepository)
	{
		_customerRepository = customerRepository;
	}

	public async Task<Result> HandleAsync(Guid customerId)
	{
		var customer = await _customerRepository.GetCustomerByIdAsync(customerId);

		if (customer is null)
		{
			return new Result() { StatusCode = HttpStatusCode.NotFound, Message = "Not found" };
		}

		await _customerRepository.DeleteCustomerAsync(customerId);

		return new Result() { StatusCode = HttpStatusCode.OK, Message = "Delete customer" };
	}
}
