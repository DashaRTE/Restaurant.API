using Restaurant.Core.Dto;
using Restaurant.Core.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Chef.Get;
public class GetChefUseCase
{
	private readonly IChefRepository _chefRepository;

	public GetChefUseCase(IChefRepository chefRepository)
	{
		_chefRepository = chefRepository;
	}

	public async Task<Result<IList<ChefDto>>> HandleAsync()
	{
		var chefs = await _chefRepository.GetChefsAsync();

		return new() { StatusCode = HttpStatusCode.OK, Message = "Get chefs", Data = chefs };
	}
}
