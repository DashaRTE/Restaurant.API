using Restaurant.Core.Dto;
using Restaurant.Core.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Waiter.GetById;
public class GetWaiterByIdUseCase
{
	private readonly IWaiterRepository _waiterRepository;

	public GetWaiterByIdUseCase(IWaiterRepository waiterRepository)
	{
		_waiterRepository = waiterRepository;
	}

	public async Task<Result<WaiterDto>> HandleAsync(Guid waiterId)
	{
		var waiter = await _waiterRepository.GetWaiterByIdAsync(waiterId);

		if (waiter is null)
		{
			return new() { StatusCode = HttpStatusCode.NotFound, Message = "Not found" };
		}

		return new() { StatusCode = HttpStatusCode.OK, Message = "Get waiter by id", Data = waiter };
	}
}
