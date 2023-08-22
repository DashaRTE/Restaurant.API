using Restaurant.Infrastucture.Repositories.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Dish.GetById;
public class GetDishByIdUseCase
{
	private readonly IDishRepository _dishRepository;

	public GetDishByIdUseCase(IDishRepository dishRepository)
	{
		_dishRepository = dishRepository;
	}

	public async Task<Result<Infrastucture.Entities.Dish>> HandleAsync(Guid dishId)
	{
		var result = await _dishRepository.GetDishByIdAsync(dishId);

		if (result is null)
		{
			return new() { StatusCode = HttpStatusCode.NotFound, Message = "Not found" };
		}

		return new() { StatusCode = HttpStatusCode.OK, Message = "Get dish by id", Data = result };
	}
}
