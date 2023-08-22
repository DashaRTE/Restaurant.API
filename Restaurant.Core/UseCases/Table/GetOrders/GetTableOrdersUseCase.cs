using Restaurant.Infrastucture.Repositories.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Table.GetOrders;
public class GetTableOrdersUseCase
{
	private readonly ITableRepository _tableRepository;

	public GetTableOrdersUseCase(ITableRepository tableRepository)
	{
		_tableRepository = tableRepository;
	}

	public async Task<Result<List<Infrastucture.Entities.Order>>> HandleAsync(Guid tableId)
	{
		var result = await _tableRepository.GetTableOrdersAsync(tableId);

		if (result is null)
		{
			return new() { StatusCode = HttpStatusCode.NotFound, Message = "Not found" };
		}

		var orders = result.Orders.ToList();

		return new() { StatusCode = HttpStatusCode.OK, Message = "Get table orders", Data = orders };
	}
}
