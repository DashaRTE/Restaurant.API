using Restaurant.Core.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Dish.Create;
public class CreateDishUseCase
{
	private readonly IDishRepository _dishRepository;

	public CreateDishUseCase(IDishRepository dishRepository)
	{
		_dishRepository = dishRepository;
	}

	public async Task<Result> HandleAsync(string name)
	{
		await _dishRepository.CreateDishAsync(name);

		return new Result() { StatusCode = HttpStatusCode.Created, Message = "Create dish" };
	}
}
