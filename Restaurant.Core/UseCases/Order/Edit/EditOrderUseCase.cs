using Restaurant.Infrastucture.Repositories.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Order.Edit;
public class EditOrderUseCase
{
	private readonly IOrderRepository _orderRepository;
	private readonly ICustomerRepository _customerRepository;
	private readonly IWaiterRepository _waiterRepository;
	private readonly IChefRepository _chefRepository;
	private readonly ITableRepository _tableRepository;

	public EditOrderUseCase(
		IOrderRepository orderRepository,
		IChefRepository chefRepository,
		ICustomerRepository customerRepository,
		IWaiterRepository waiterRepository,
		ITableRepository tableRepository)
	{
		_orderRepository = orderRepository;
		_customerRepository = customerRepository;
		_waiterRepository = waiterRepository;
		_tableRepository = tableRepository;
		_chefRepository = chefRepository;
	}

	public async Task<Result> HandleAsync(EditOrderRequest request)
	{
		var order = await _orderRepository.GetOrderByIdAsync(request.OrderId);

		if (order is null)
		{
			return new() { StatusCode = HttpStatusCode.NotFound, Message = "Not found order" };
		}

		var chef = await _chefRepository.GetChefByIdAsync(request.ChefId);

		if (chef is null)
		{
			return new() { StatusCode = HttpStatusCode.NotFound, Message = "Not found chef" };
		}

		var customer = await _customerRepository.GetCustomerByIdAsync(request.CustomerId);

		if (customer is null)
		{
			return new() { StatusCode = HttpStatusCode.NotFound, Message = "Not found customer" };
		}

		var waiter = await _waiterRepository.GetWaiterByIdAsync(request.WaiterId);

		if (waiter is null)
		{
			return new() { StatusCode = HttpStatusCode.NotFound, Message = "Not found waiter" };
		}

		var table = await _tableRepository.GetTableByIdAsync(request.TableId);

		if (table is null)
		{
			return new() { StatusCode = HttpStatusCode.NotFound, Message = "Not found table" };
		}

		await _orderRepository.EditOrderAsync(request.OrderId, request.Number, request.Price, request.ChefId, request.CustomerId,
			request.WaiterId, request.TableId);

		return new() { StatusCode = HttpStatusCode.Created, Message = "Edit order" };
	}
}
