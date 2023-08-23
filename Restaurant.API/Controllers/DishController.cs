using Microsoft.AspNetCore.Mvc;
using Restaurant.Core;
using System.ComponentModel.DataAnnotations;
using Restaurant.Core.UseCases.Dish.Get;
using Restaurant.Core.UseCases.Dish.Create;
using Restaurant.Core.UseCases.Dish.Edit;
using Restaurant.Core.UseCases.Dish.Delete;
using Restaurant.Core.UseCases.Dish.GetById;
using System.Text.Json;

namespace Restaurant.API.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/dish")]

public class DishController
{
	private readonly GetDishUseCase _getDishUseCase;
	private readonly CreateDishUseCase _createDishUseCase;
	private readonly EditDishUseCase _editDishUseCase;
	private readonly DeleteDishUseCase _deleteDishUseCase;
	private readonly GetDishByIdUseCase _getDishByIdUseCase;

	public DishController(GetDishUseCase getDishUseCase,
		CreateDishUseCase createDishUseCase, 
		EditDishUseCase editDishUseCase, 
		DeleteDishUseCase deleteDishUseCase, 
		GetDishByIdUseCase getDishByIdUseCase)
	{
		_getDishUseCase = getDishUseCase;
		_createDishUseCase = createDishUseCase;
		_editDishUseCase = editDishUseCase;
		_deleteDishUseCase = deleteDishUseCase;
		_getDishByIdUseCase = getDishByIdUseCase;
	}

	[HttpGet, Route("get")]
	public async Task<ContentResult> GetDishesAsync()
	{
		var result = await _getDishUseCase.HandleAsync();

		var json = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			WriteIndented = true,
		});

		var content = new ContentResult()
		{
			Content = json, ContentType = "application/json", StatusCode = (int)result.StatusCode
		};

		return content;
	}

	[HttpPost, Route("create")]
	public async Task<Result> CreateDishAsync([Required, FromBody] string name)
	{
		var result = await _createDishUseCase.HandleAsync(name);

		return result;
	}

	[HttpPut, Route("edit")]
	public async Task<Result> EditDishAsync([Required, FromBody] Restaurant.API.Requests.EditDishRequest request)
	{
		var result = await _editDishUseCase.HandleAsync(new(request.DishId, request.Name));
		
		return result;
	}

	[HttpDelete, Route("delete/{dishId}")]
	public async Task<Result> DeleteDishAsync([Required] Guid dishId)
	{
		var result = await _deleteDishUseCase.HandleAsync(dishId);
		
		return result;
	}

	[HttpGet, Route("get/{customerId}")]
	public async Task<ContentResult> GetDishByIdAsync([Required] Guid dishId)
	{
		var result = await _getDishByIdUseCase.HandleAsync(dishId);

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
