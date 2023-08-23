using Restaurant.Core.Dto;
using Restaurant.Core.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Dish.Get;
public class GetDishUseCase
{
	private readonly IDishRepository _dishRepository;

	public GetDishUseCase(IDishRepository dishRepository)
	{
		_dishRepository = dishRepository;
	}

	public async Task<Result<IList<DishDto>>> HandleAsync()
	{
		var dishes = await _dishRepository.GetDishesAsync();

		return new() { StatusCode = HttpStatusCode.OK, Message = "Get dishes", Data = dishes };
	}
}
