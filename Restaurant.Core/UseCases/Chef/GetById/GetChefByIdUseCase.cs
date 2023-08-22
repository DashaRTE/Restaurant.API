using Restaurant.Infrastucture.Repositories.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Chef.GetById;
public class GetChefByIdUseCase
{
	private readonly IChefRepository _chefRepository;

	public GetChefByIdUseCase(IChefRepository chefRepository)
	{
		_chefRepository = chefRepository;
	}

	public async Task<Result<Infrastucture.Entities.Chef>> HandleAsync(Guid chefId)
	{
		var result = await _chefRepository.GetChefByIdAsync(chefId);

		if (result is null)
		{
			return new() { StatusCode = HttpStatusCode.NotFound, Message = "Not found"};
		}

		return new() { StatusCode = HttpStatusCode.OK, Message = "Get chef by id", Data = result };
	}
}
