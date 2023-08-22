using Restaurant.Infrastucture.Repositories.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Order.Get;
public class GetOrderUseCase
{
	private readonly IOrderRepository _orderRepository;

	public GetOrderUseCase(IOrderRepository orderRepository)
	{
		_orderRepository = orderRepository;
	}

	public async Task<Result<List<Infrastucture.Entities.Order>>> HandleAsync()
	{
		var result = await _orderRepository.GetOrdersAsync();

		return new() { StatusCode = HttpStatusCode.OK, Message = "Get orders", Data = result };
	}
}
