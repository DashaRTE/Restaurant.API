using Microsoft.AspNetCore.Mvc;
using Restaurant.API.Requests;
using Restaurant.API.Responses;
using Restaurant.Infrastucture.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.API.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/table")]
public class TableController : ControllerBase
{
	private readonly ITableRepository _tableRepository;

	public TableController(ITableRepository tableRepository)
	{
		_tableRepository = tableRepository;
	}

	[HttpGet, Route("get")]
	public async Task<IActionResult> GetTablesAsync()
	{
		var tables = await _tableRepository.GetTablesAsync();
		return Ok(tables);
	}

	[HttpPost, Route("create")]
	public async Task<IActionResult> CreateTableAsync([Required, FromBody] int Number)
	{
		var table = await _tableRepository.CreateTableAsync(Number);
		return Ok(table);
	}

	[HttpPut, Route("edit")]
	public async Task<IActionResult> EditTableAsync([Required, FromBody] EditTableRequest Request)
	{
		var table = await _tableRepository.EditTableAsync(Request.TableId, Request.Number);
		return Ok(table);
	}

	[HttpDelete, Route("delete/{tableId}")]
	public async Task<IActionResult> DeleteTableAsync([Required] Guid tableId)
	{
		await _tableRepository.DeleteTableAsync(tableId);
		return Ok();
	}

	[HttpGet, Route("get/{tableId}")]
	public async Task<IActionResult> GetTableByIdAsync([Required] Guid tableId)
	{
		var table = await _tableRepository.GetTableByIdAsync(tableId);
		if (table is null)
		{
			return NotFound();
		}

		return Ok(table);
	}

	[HttpGet, Route("get/orders/{tableId}")]
	public async Task<IActionResult> GetTableOrdersAsync([Required] Guid tableId)
	{
		var table = await _tableRepository.GetTableOrdersAsync(tableId);

		if (table?.Orders is null)
		{
			return NotFound();
		}

		return Ok(new TableOrdersResponse(table.Number,
			table.Orders.Select(order => new TableOrderResponse(order.Number, order.Price)).ToList()));
	}
}