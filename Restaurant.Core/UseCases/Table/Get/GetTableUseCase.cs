using Restaurant.Core.Dto;
using Restaurant.Core.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Table.Get;
public class GetTableUseCase
{
	private readonly ITableRepository _tableRepository;

	public GetTableUseCase(ITableRepository tableRepository)
	{
		_tableRepository = tableRepository;
	}

	public async Task<Result<IList<TableDto>>> HandleAsync()
	{
		var tables = await _tableRepository.GetTablesAsync();

		return new() { StatusCode = HttpStatusCode.OK, Message = "Get tables", Data = tables };
	}
}
