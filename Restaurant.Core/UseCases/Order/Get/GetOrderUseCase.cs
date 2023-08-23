using Restaurant.Core.Dto;
using Restaurant.Core.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Order.Get;
public class GetOrderUseCase
{
	private readonly IOrderRepository _orderRepository;

	public GetOrderUseCase(IOrderRepository orderRepository)
	{
		_orderRepository = orderRepository;
	}

	public async Task<Result<IList<OrderDto>>> HandleAsync()
	{
		var orders = await _orderRepository.GetOrdersAsync();

		return new() { StatusCode = HttpStatusCode.OK, Message = "Get orders", Data = orders };
	}
}
