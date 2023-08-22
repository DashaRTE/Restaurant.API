using Restaurant.Infrastucture.Repositories.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Dish.Get;
public class GetDishUseCase
{
	private readonly IDishRepository _dishRepository;

	public GetDishUseCase(IDishRepository dishRepository)
	{
		_dishRepository = dishRepository;
	}

	public async Task<Result<List<Infrastucture.Entities.Dish>>> HandleAsync()
	{
		var result = await _dishRepository.GetDishesAsync();

		return new() { StatusCode = HttpStatusCode.OK, Message = "Get dishes", Data = result };
	}
}
