using Restaurant.Core.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Dish.Edit;
public class EditDishUseCase
{
	private readonly IDishRepository _dishRepository;

	public EditDishUseCase(IDishRepository dishRepository)
	{
		_dishRepository = dishRepository;
	}

	public async Task<Result> HandleAsync(EditDishRequest request)
	{
		var dish = await _dishRepository.GetDishByIdAsync(request.DishId);

		if (dish is null)
		{
			return new Result() { StatusCode = HttpStatusCode.NotFound, Message = "Not found" };
		}

		await _dishRepository.EditDishAsync(request.DishId, request.Name);

		return new Result() { StatusCode = HttpStatusCode.OK, Message = "Edit dish" };
	}
}
