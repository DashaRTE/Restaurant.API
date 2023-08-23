using Restaurant.Core.Dto;
using Restaurant.Core.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Chef.GetById;
public class GetChefByIdUseCase
{
	private readonly IChefRepository _chefRepository;

	public GetChefByIdUseCase(IChefRepository chefRepository)
	{
		_chefRepository = chefRepository;
	}

	public async Task<Result<ChefDto>> HandleAsync(Guid chefId)
	{
		var chef = await _chefRepository.GetChefByIdAsync(chefId);

		if (chef is null)
		{
			return new() { StatusCode = HttpStatusCode.NotFound, Message = "Not found"};
		}

		return new() { StatusCode = HttpStatusCode.OK, Message = "Get chef by id", Data = chef };
	}
}
