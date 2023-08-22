using Restaurant.Infrastucture.Repositories.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Chef.Get;
public class GetChefUseCase
{
	private readonly IChefRepository _chefRepository;

	public GetChefUseCase(IChefRepository chefRepository)
	{
		_chefRepository = chefRepository;
	}

	public async Task<Result<List<Infrastucture.Entities.Chef>>> HandleAsync()
	{
		var result = await _chefRepository.GetChefsAsync();

		return new() { StatusCode = HttpStatusCode.OK, Message = "Get chefs", Data = result };
	}
}
