using Restaurant.Core.Dto;
using Restaurant.Core.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Waiter.Get;
public class GetWaiterUseCase
{
	private readonly IWaiterRepository _waiterRepository;

	public GetWaiterUseCase(IWaiterRepository waiterRepository)
	{
		_waiterRepository = waiterRepository;
	}

	public async Task<Result<IList<WaiterDto>>> HandleAsync()
	{
		var waiters = await _waiterRepository.GetWaitersAsync();

		return new() { StatusCode = HttpStatusCode.OK, Message = "Get waiters", Data = waiters };
	}
}
