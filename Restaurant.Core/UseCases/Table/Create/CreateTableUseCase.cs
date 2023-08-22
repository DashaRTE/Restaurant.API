using Restaurant.Infrastucture.Repositories.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Table.Create;
public class CreateTableUseCase
{
	private readonly ITableRepository _tableRepository;

	public CreateTableUseCase(ITableRepository tableRepository)
	{
		_tableRepository = tableRepository;
	}

	public async Task<Result> HandleAsync(int number)
	{
		await _tableRepository.CreateTableAsync(number);

		return new Result() { StatusCode = HttpStatusCode.Created, Message = "Create table" };
	}
}
