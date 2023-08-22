using Restaurant.Infrastucture.Repositories.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Waiter.Delete;
public class DeleteWaiterUseCase
{
	private readonly IWaiterRepository _waiterRepository;

	public DeleteWaiterUseCase(IWaiterRepository waiterRepository)
	{
		_waiterRepository = waiterRepository;
	}

	public async Task<Result> HandleAsync(Guid waiterId)
	{
		var waiter = await _waiterRepository.GetWaiterByIdAsync(waiterId);

		if (waiter is null)
		{
			return new Result() { StatusCode = HttpStatusCode.NotFound, Message = "Not found" };
		}

		await _waiterRepository.DeleteWaiterAsync(waiterId);

		return new Result() { StatusCode = HttpStatusCode.OK, Message = "Delete waiter" };
	}
}
