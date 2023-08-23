using Restaurant.Core.Dto;
using Restaurant.Core.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Table.GetOrders;
public class GetTableOrdersUseCase
{
	private readonly ITableRepository _tableRepository;

	public GetTableOrdersUseCase(ITableRepository tableRepository)
	{
		_tableRepository = tableRepository;
	}

	public async Task<Result<IList<OrderDto>>> HandleAsync(Guid tableId)
	{
		var table = await _tableRepository.GetTableOrdersAsync(tableId);

		if (table is null)
		{
			return new() { StatusCode = HttpStatusCode.NotFound, Message = "Not found" };
		}

		return new() { StatusCode = HttpStatusCode.OK, Message = "Get table orders", Data = table.Orders };
	}
}
