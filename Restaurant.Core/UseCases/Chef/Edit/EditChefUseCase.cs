using Restaurant.Core.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Chef.Edit;
public class EditChefUseCase
{
	private readonly IChefRepository _chefRepository;

	public EditChefUseCase(IChefRepository chefRepository)
	{
		_chefRepository = chefRepository;
	}

	public async Task<Result> HandleAsync(EditChefRequest request)
	{
		var customer = await _chefRepository.GetChefByIdAsync(request.ChefId);

		if (customer is null)
		{
			return new Result() { StatusCode = HttpStatusCode.NotFound, Message = "Not found" };
		}

		await _chefRepository.EditChefAsync(request.ChefId, request.Email, request.Name, request.Password);

		return new Result() { StatusCode = HttpStatusCode.OK, Message = "Edit chef" };
	}
}
