using Restaurant.Core.Dto;
using Restaurant.Core.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Order.GetById;
public class GetOrderByIdUseCase
{
	private readonly IOrderRepository _orderRepository;

	public GetOrderByIdUseCase(IOrderRepository orderRepository)
	{
		_orderRepository = orderRepository;
	}

	public async Task<Result<OrderDto>> HandleAsync(Guid orderId)
	{
		var order = await _orderRepository.GetOrderByIdAsync(orderId);

		if (order is null)
		{
			return new() { StatusCode = HttpStatusCode.NotFound, Message = "Not found" };
		}

		return new() { StatusCode = HttpStatusCode.OK, Message = "Get order by id", Data = order };
	}
}
