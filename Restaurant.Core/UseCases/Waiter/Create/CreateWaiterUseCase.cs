using Restaurant.Core.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Waiter.Create;
public class CreateWaiterUseCase
{
	private readonly IWaiterRepository _waiterRepository;

	public CreateWaiterUseCase(IWaiterRepository waiterRepository)
	{
		_waiterRepository = waiterRepository;
	}

	public async Task<Result> HandleAsync(CreateWaiterRequest request)
	{
		await _waiterRepository.CreateWaiterAsync(request.Email, request.Name, request.Password);

		return new Result() { StatusCode = HttpStatusCode.Created, Message = "Create waiter" };
	}
}
