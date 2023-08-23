using Restaurant.Core.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Table.Delete;
public class DeleteTableUseCase
{
	private readonly ITableRepository _tableRepository;

	public DeleteTableUseCase(ITableRepository tableRepository)
	{
		_tableRepository = tableRepository;
	}

	public async Task<Result> HandleAsync(Guid tableId)
	{
		var table = await _tableRepository.GetTableByIdAsync(tableId);

		if (table is null)
		{
			return new Result() { StatusCode = HttpStatusCode.NotFound, Message = "Not found" };
		}

		await _tableRepository.DeleteTableAsync(tableId);

		return new Result() { StatusCode = HttpStatusCode.OK, Message = "Delete table" };
	}
}
