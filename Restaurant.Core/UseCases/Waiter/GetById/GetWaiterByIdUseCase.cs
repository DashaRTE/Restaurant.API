using Restaurant.Infrastucture.Repositories.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Waiter.GetById;
public class GetWaiterByIdUseCase
{
	private readonly IWaiterRepository _waiterRepository;

	public GetWaiterByIdUseCase(IWaiterRepository waiterRepository)
	{
		_waiterRepository = waiterRepository;
	}

	public async Task<Result<Infrastucture.Entities.Waiter>> HandleAsync(Guid waiterId)
	{
		var result = await _waiterRepository.GetWaiterByIdAsync(waiterId);

		if (result is null)
		{
			return new() { StatusCode = HttpStatusCode.NotFound, Message = "Not found" };
		}

		return new() { StatusCode = HttpStatusCode.OK, Message = "Get waiter by id", Data = result };
	}
}
