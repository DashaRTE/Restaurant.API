using Restaurant.Core.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Waiter.Edit;
public class EditWaiterUseCase
{
	private readonly IWaiterRepository _waiterRepository;

	public EditWaiterUseCase(IWaiterRepository waiterRepository)
	{
		_waiterRepository = waiterRepository;
	}

	public async Task<Result> HandleAsync(EditWaiterRequest request)
	{
		var waiter = await _waiterRepository.GetWaiterByIdAsync(request.WaiterId);

		if (waiter is null)
		{
			return new Result() { StatusCode = HttpStatusCode.NotFound, Message = "Not found" };
		}

		await _waiterRepository.EditWaiterAsync(request.WaiterId, request.Email, request.Name, request.Password);

		return new Result() { StatusCode = HttpStatusCode.OK, Message = "Edit waiter" };
	}
}
