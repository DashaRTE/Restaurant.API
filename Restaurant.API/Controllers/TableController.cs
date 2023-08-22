using Microsoft.AspNetCore.Mvc;
using Restaurant.Core;
using Restaurant.Core.UseCases.Table.Create;
using Restaurant.Core.UseCases.Table.Delete;
using Restaurant.Core.UseCases.Table.Edit;
using Restaurant.Core.UseCases.Table.Get;
using Restaurant.Core.UseCases.Table.GetById;
using Restaurant.Core.UseCases.Table.GetOrders;
using Restaurant.Infrastucture.Entities;
using System.ComponentModel.DataAnnotations;

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


	public TableController(GetTableUseCase getTableUseCase, CreateTableUseCase createTableUseCase, EditTableUseCase editTableUseCase, DeleteTableUseCase deleteTableUseCase, GetTableByIdUseCase getTableByIdUseCase, GetTableOrdersUseCase getTableOrdersUseCase)
	{
		_getTableUseCase = getTableUseCase;
		_createTableUseCase = createTableUseCase;
		_editTableUseCase = editTableUseCase;
		_deleteTableUseCase = deleteTableUseCase;
		_getTableByIdUseCase = getTableByIdUseCase;
		_getTableOrdersUseCase = getTableOrdersUseCase;
	}

	[HttpGet, Route("get")]
	public async Task<Result<List<Table>>> GetTablesAsync()
	{
		return await _getTableUseCase.HandleAsync();
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
	public async Task<Result<Table>> GetTableByIdAsync([Required] Guid tableId)
	{
		var result = await _getTableByIdUseCase.HandleAsync(tableId);

		return result;
	}

	[HttpGet, Route("get/orders/{tableId}")]
	public async Task<Result<List<Order>>> GetTableOrdersAsync([Required] Guid tableId)
	{
		var result = await _getTableOrdersUseCase.HandleAsync(tableId);

		return result;
	}
}