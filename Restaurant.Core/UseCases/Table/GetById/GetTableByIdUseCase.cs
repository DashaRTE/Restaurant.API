using Restaurant.Infrastucture.Repositories.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Table.GetById;
public class GetTableByIdUseCase
{
	private readonly ITableRepository _tableRepository;

	public GetTableByIdUseCase(ITableRepository tableRepository)
	{
		_tableRepository = tableRepository;
	}

	public async Task<Result<Infrastucture.Entities.Table>> HandleAsync(Guid tableId)
	{
		var table = await _tableRepository.GetTableByIdAsync(tableId);

		if (table is null)
		{
			return new() { StatusCode = HttpStatusCode.NotFound, Message = "Not found" };
		}

		return new() { StatusCode = HttpStatusCode.OK, Message = "Get table by id", Data = table };
	}
}
