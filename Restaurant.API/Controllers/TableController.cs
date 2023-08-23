using Microsoft.AspNetCore.Mvc;
using Restaurant.Core;
using Restaurant.Core.UseCases.Table.Create;
using Restaurant.Core.UseCases.Table.Delete;
using Restaurant.Core.UseCases.Table.Edit;
using Restaurant.Core.UseCases.Table.Get;
using Restaurant.Core.UseCases.Table.GetById;
using Restaurant.Core.UseCases.Table.GetOrders;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Restaurant.API.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/table")]
public class TableController : ControllerBase
{
	private readonly GetTableUseCase _getTableUseCase;
	private readonly CreateTableUseCase _createTableUseCase;
	private readonly EditTableUseCase _editTableUseCase;
	private readonly DeleteTableUseCase _deleteTableUseCase;
	private readonly GetTableByIdUseCase _getTableByIdUseCase;
	private readonly GetTableOrdersUseCase _getTableOrdersUseCase;


	public TableController(GetTableUseCase getTableUseCase, 
		CreateTableUseCase createTableUseCase, 
		EditTableUseCase editTableUseCase, 
		DeleteTableUseCase deleteTableUseCase, 
		GetTableByIdUseCase getTableByIdUseCase, 
		GetTableOrdersUseCase getTableOrdersUseCase)
	{
		_getTableUseCase = getTableUseCase;
		_createTableUseCase = createTableUseCase;
		_editTableUseCase = editTableUseCase;
		_deleteTableUseCase = deleteTableUseCase;
		_getTableByIdUseCase = getTableByIdUseCase;
		_getTableOrdersUseCase = getTableOrdersUseCase;
	}

	[HttpGet, Route("get")]
	public async Task<ContentResult> GetTablesAsync()
	{
		var result = await _getTableUseCase.HandleAsync();

		var json = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			WriteIndented = true,
		});

		var content = new ContentResult()
		{
			Content = json,
			ContentType = "application/json",
			StatusCode = (int)result.StatusCode
		};

		return content;
	}
	

	[HttpPost, Route("create")]
	public async Task<Result> CreateTableAsync([Required, FromBody] int number)
	{
		var result = await _createTableUseCase.HandleAsync(number);
		return result;
	}

	[HttpPut, Route("edit")]
	public async Task<Result> EditTableAsync([Required, FromBody] EditTableRequest request)
	{
		var result = await _editTableUseCase.HandleAsync(new(request.TableId, request.Number));

		return result;
	}

	[HttpDelete, Route("delete/{tableId}")]
	public async Task<Result> DeleteTableAsync([Required] Guid tableId)
	{
		var result = await _deleteTableUseCase.HandleAsync(tableId);

		return result;
	}

	[HttpGet, Route("get/{tableId}")]
	public async Task<ContentResult> GetTableByIdAsync([Required] Guid tableId)
	{
		var result = await _getTableByIdUseCase.HandleAsync(tableId);

		var json = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			WriteIndented = true,
		});

		var content = new ContentResult()
		{
			Content = json,
			ContentType = "application/json",
			StatusCode = (int)result.StatusCode
		};

		return content;
	}

	[HttpGet, Route("get/orders/{tableId}")]
	public async Task<ContentResult> GetTableOrdersAsync([Required] Guid tableId)
	{
		var result = await _getTableOrdersUseCase.HandleAsync(tableId);

		var json = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			WriteIndented = true,
		});

		var content = new ContentResult()
		{
			Content = json,
			ContentType = "application/json",
			StatusCode = (int)result.StatusCode
		};

		return content;
	}
}