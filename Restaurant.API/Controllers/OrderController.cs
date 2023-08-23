using Microsoft.AspNetCore.Mvc;
using Restaurant.Core;
using Restaurant.Core.UseCases.Order.AddDishes;
using Restaurant.Core.UseCases.Order.Create;
using Restaurant.Core.UseCases.Order.Edit;
using Restaurant.Core.UseCases.Order.Get;
using Restaurant.Core.UseCases.Order.GetById;
using Restaurant.Core.UseCases.Order.RemoveDishes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Restaurant.API.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/order")]
public class OrderController : ControllerBase
{
	private readonly GetOrderUseCase _getOrderUseCase;
	private readonly CreateOrderUseCase _createOrderUseCase;
	private readonly EditOrderUseCase _editOrderUseCase;
	private readonly GetOrderByIdUseCase _getOrderByIdUseCase;
	private readonly AddDishesUseCase _addDishesUseCase;
	private readonly RemoveDishesUseCase _removeDishesUseCase;

	public OrderController(
		GetOrderUseCase getOrderUseCase, 
		CreateOrderUseCase createOrderUseCase, 
		EditOrderUseCase editOrderUseCase, 
		GetOrderByIdUseCase getOrderByIdUseCase, 
		AddDishesUseCase addDishesUseCase, 
		RemoveDishesUseCase removeDishesUseCase)
	{
		_getOrderUseCase = getOrderUseCase;
		_createOrderUseCase = createOrderUseCase;
		_editOrderUseCase = editOrderUseCase;
		_getOrderByIdUseCase = getOrderByIdUseCase;
		_addDishesUseCase = addDishesUseCase;
		_removeDishesUseCase = removeDishesUseCase;
	}

	[HttpGet, Route("get")]
	public async Task<ContentResult> GetOrdersAsync()
	{
		var result = await _getOrderUseCase.HandleAsync();

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
	public async Task<Result> CreateOrderAsync([Required, FromBody] Requests.CreateOrderRequest request)
	{
		var result = await _createOrderUseCase.HandleAsync(new(request.Number, request.Price, request.ChefId,
			request.CustomerId, request.WaiterId, request.TableId));

		return result;
	}

	[HttpPut, Route("edit")]
	public async Task<Result> EditOrderAsync([Required, FromBody] Requests.EditOrderRequest request)
	{
		var result = await _editOrderUseCase.HandleAsync(new(request.OrderId, request.Number, request.Price,
			request.ChefId, request.CustomerId, request.WaiterId, request.TableId));

		return result;
	}

	[HttpGet, Route("get/{orderId}")]
	public async Task<ContentResult> GetOrderByIdAsync([Required] Guid orderId)
	{
		var result = await _getOrderByIdUseCase.HandleAsync(orderId);

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

	[HttpPost, Route("addDishes/{orderId}")]
	public async Task<Result> AddDishesAsync([Required, FromBody] Requests.AddDishesRequest request)
	{
		var result = await _addDishesUseCase.HandleAsync(new(request.OrderId, request.DishId));

		return result;
	}

	[HttpDelete, Route("removeDishes/{orderId}")]
	public async Task<Result> RemoveDishesAsync([Required, FromBody] Requests.RemoveDishesRequest request)
	{
		var result = await _removeDishesUseCase.HandleAsync(new(request.OrderId, request.DishId));

		return result;
	}
}