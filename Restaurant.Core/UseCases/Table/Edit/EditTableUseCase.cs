using Restaurant.Infrastucture.Repositories.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Table.Edit;
public class EditTableUseCase
{
	private readonly ITableRepository _tableRepository;

	public EditTableUseCase(ITableRepository tableRepository)
	{
		_tableRepository = tableRepository;
	}

	public async Task<Result> HandleAsync(EditTableRequest request)
	{
		var table = await _tableRepository.GetTableByIdAsync(request.TableId);

		if (table is null)
		{
			return new Result() { StatusCode = HttpStatusCode.NotFound, Message = "Not found" };
		}

		await _tableRepository.EditTableAsync(request.TableId, request.Number);

		return new Result() { StatusCode = HttpStatusCode.OK, Message = "Edit table" };
	}
}
