using Restaurant.Core.Dto;
using Restaurant.Core.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Dish.GetById;
public class GetDishByIdUseCase
{
	private readonly IDishRepository _dishRepository;

	public GetDishByIdUseCase(IDishRepository dishRepository)
	{
		_dishRepository = dishRepository;
	}

	public async Task<Result<DishDto>> HandleAsync(Guid dishId)
	{
		var dish = await _dishRepository.GetDishByIdAsync(dishId);

		if (dish is null)
		{
			return new() { StatusCode = HttpStatusCode.NotFound, Message = "Not found dish" };
		}

		return new() { StatusCode = HttpStatusCode.OK, Message = "Get dish by id", Data = dish };
	}
}
