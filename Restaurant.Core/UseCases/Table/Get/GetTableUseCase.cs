using Restaurant.Infrastucture.Repositories.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Table.Get;
public class GetTableUseCase
{
	private readonly ITableRepository _tableRepository;

	public GetTableUseCase(ITableRepository tableRepository)
	{
		_tableRepository = tableRepository;
	}

	public async Task<Result<List<Infrastucture.Entities.Table>>> HandleAsync()
	{
		var result = await _tableRepository.GetTablesAsync();

		return new() { StatusCode = HttpStatusCode.OK, Message = "Get tables", Data = result };
	}
}
