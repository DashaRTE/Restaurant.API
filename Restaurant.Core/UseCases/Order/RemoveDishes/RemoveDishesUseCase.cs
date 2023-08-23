using Restaurant.Core.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Order.RemoveDishes;
public class RemoveDishesUseCase
{
	private readonly IOrderRepository _orderRepository;
	private readonly IDishRepository _dishRepository;

	public RemoveDishesUseCase(IOrderRepository orderRepository, IDishRepository dishRepository)
	{
		_orderRepository = orderRepository;
		_dishRepository = dishRepository;
	}

	public async Task<Result> HandleAsync(RemoveDishesRequest request)
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

		await _orderRepository.RemoveDishesAsync(request.OrderId, request.DishId);

		return new Result() { StatusCode = HttpStatusCode.Created, Message = "Remove dishes from order" };
	}
}
