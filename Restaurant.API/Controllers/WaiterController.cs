using Microsoft.AspNetCore.Mvc;
using Restaurant.API.Requests;
using System.ComponentModel.DataAnnotations;
using Restaurant.Core.UseCases.Waiter.Get;
using Restaurant.Core;
using Restaurant.Core.UseCases.Waiter.Create;
using Restaurant.Core.UseCases.Waiter.Edit;
using Restaurant.Core.UseCases.Waiter.Delete;
using Restaurant.Core.UseCases.Waiter.GetById;
using System.Text.Json;

namespace Restaurant.API.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/waiter")]

public class WaiterController :ControllerBase
{
	private readonly CreateWaiterUseCase _createWaiterUseCase;
	private readonly GetWaiterUseCase _getWaiterUseCase;
	private readonly EditWaiterUseCase _editWaiterUseCase;
	private readonly DeleteWaiterUseCase _deleteWaiterUseCase;
	private readonly GetWaiterByIdUseCase _getWaiterByIdUseCase;

	public WaiterController(GetWaiterUseCase getWaiterUseCase, 
		CreateWaiterUseCase createWaiterUseCase,
		EditWaiterUseCase editWaiterUseCase, 
		DeleteWaiterUseCase deleteWaiterUseCase, 
		GetWaiterByIdUseCase getWaiterByIdUseCase)
	{
		_getWaiterUseCase = getWaiterUseCase;
		_createWaiterUseCase = createWaiterUseCase;
		_editWaiterUseCase = editWaiterUseCase;
		_deleteWaiterUseCase = deleteWaiterUseCase;
		_getWaiterByIdUseCase = getWaiterByIdUseCase;
	}

    [HttpGet, Route("get")]
    public async Task<ContentResult> GetWaitersAsync()
    {
        var result = await _getWaiterUseCase.HandleAsync();

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
    public async Task<Result> CreateWaiterAsync([Required, FromBody] CreateUserRequest request)
    {
        var result = await _createWaiterUseCase.HandleAsync(new(request.Name, request.Email, request.Password));

        return result;
    }

    [HttpPut, Route("edit")]
    public async Task<Result> EditWaiterAsync([Required, FromBody] Requests.EditWaiterRequest request)
	{
		var result = await _editWaiterUseCase.HandleAsync(new(request.WaiterId , request.Name, request.Email, request.Password));
		
		return result;
	}

	[HttpDelete, Route("delete/{waiterId}")]
	public async Task<Result> DeleteWaiterAsync([Required] Guid waiterId)
	{
		var result = await _deleteWaiterUseCase.HandleAsync(waiterId);

		return result;
	}

	[HttpGet, Route("get/{waiterId}")]
	public async Task<ContentResult> GetWaiterByIdAsync([Required] Guid waiterId)
	{
		var result = await _getWaiterByIdUseCase.HandleAsync(waiterId);

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
