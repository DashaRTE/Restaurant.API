using Restaurant.Infrastucture.Repositories.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Chef.Delete;
public class DeleteChefUseCase
{
	private readonly IChefRepository _chefRepository;

	public DeleteChefUseCase(IChefRepository chefRepository)
	{
		_chefRepository = chefRepository;
	}

	public async Task<Result> HandleAsync(Guid chefId)
	{
		var chef = await _chefRepository.GetChefByIdAsync(chefId);

		if (chef is null)
		{
			return new Result() { StatusCode = HttpStatusCode.NotFound, Message = "Not found" };
		}

		await _chefRepository.DeleteChefAsync(chefId);

		return new Result() { StatusCode = HttpStatusCode.OK, Message = "Delete chef" };
	}
}
