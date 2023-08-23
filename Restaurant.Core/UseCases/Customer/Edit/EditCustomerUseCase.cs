using Restaurant.Core.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Customer.Edit;
public class EditCustomerUseCase
{
	private readonly ICustomerRepository _customerRepository;

	public EditCustomerUseCase(ICustomerRepository customerRepository)
	{
		_customerRepository = customerRepository;
	}

	public async Task<Result> HandleAsync(EditCustomerRequest request)
	{
		var customer = await _customerRepository.GetCustomerByIdAsync(request.CustomerId);

		if (customer is null)
		{
			return new Result() { StatusCode = HttpStatusCode.NotFound, Message = "Not found" }; 
		}

		await _customerRepository.EditCustomerAsync(request.CustomerId, request.Email, request.Name, request.Password);

		return new Result() { StatusCode = HttpStatusCode.OK, Message = "Edit customer" };
	}
}
