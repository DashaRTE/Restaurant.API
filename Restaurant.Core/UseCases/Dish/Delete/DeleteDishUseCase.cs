using Restaurant.Infrastucture.Repositories.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Dish.Delete;
public class DeleteDishUseCase
{
	private readonly IDishRepository _dishRepository;

	public DeleteDishUseCase(IDishRepository dishRepository)
	{
		_dishRepository = dishRepository;
	}

	public async Task<Result> HandleAsync(Guid dishId)
	{
		var dish = await _dishRepository.GetDishByIdAsync(dishId);

		if (dish is null)
		{
			return new Result() { StatusCode = HttpStatusCode.NotFound, Message = "Not found" };
		}

		await _dishRepository.DeleteDishAsync(dishId);

		return new Result() { StatusCode = HttpStatusCode.OK, Message = "Delete dish" };
	}
}
