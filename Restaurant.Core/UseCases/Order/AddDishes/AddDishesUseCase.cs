using Restaurant.Infrastucture.Repositories.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Order.AddDishes;
public class AddDishesUseCase
{
	private readonly IOrderRepository _orderRepository;
	private readonly IDishRepository _dishRepository;

	public AddDishesUseCase(IOrderRepository orderRepository, IDishRepository dishRepository)
	{
		_orderRepository = orderRepository;
		_dishRepository = dishRepository;
	}

	public async Task<Result> HandleAsync(AddDishesRequest request)
	{
		var order = await _orderRepository.GetOrderByIdAsync(request.OrderId);

		if (order is null)
		{
			return new() { StatusCode = HttpStatusCode.NotFound, Message = "Not found order" };
		}

		var dish = await _dishRepository.GetDishByIdAsync(request.DishId);

		if (dish is null)
		{
			return new() { StatusCode = HttpStatusCode.NotFound, Message = "Not found dish" };
		}

		await _orderRepository.AddDishesAsync(request.OrderId, request.DishId);

		return new Result() { StatusCode = HttpStatusCode.Created, Message = "Add dishes to order" };
	}
}
