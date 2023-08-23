using Microsoft.AspNetCore.Mvc;
using Restaurant.API.Requests;
using Restaurant.Core;
using Restaurant.Core.UseCases.Owner.Create;
using Restaurant.Core.UseCases.Owner.Delete;
using Restaurant.Core.UseCases.Owner.Edit;
using Restaurant.Core.UseCases.Owner.Get;
using Restaurant.Core.UseCases.Owner.GetById;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Restaurant.API.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/owner")]

public class OwnerController : ControllerBase
{
    private readonly GetOwnerUseCase _getOwnerUseCase;
    private readonly CreateOwnerUseCase _createOwnerUseCase;
    private readonly EditOwnerUseCase _editOwnerUseCase;
    private readonly DeleteOwnerUseCase _deleteOwnerUseCase;
    private readonly GetOwnerByIdUseCase _getOwnerByIdUseCase;

	public OwnerController(GetOwnerUseCase getOwnerUseCase, 
		CreateOwnerUseCase createOwnerUseCase, 
		EditOwnerUseCase editOwnerUseCase,
		DeleteOwnerUseCase deleteOwnerUseCase, 
		GetOwnerByIdUseCase getOwnerByIdUseCase)
	{
		_getOwnerUseCase = getOwnerUseCase;
		_createOwnerUseCase = createOwnerUseCase;
		_editOwnerUseCase = editOwnerUseCase;
		_deleteOwnerUseCase = deleteOwnerUseCase;
		_getOwnerByIdUseCase = getOwnerByIdUseCase;
	}

    [HttpGet, Route("get")]
    public async Task<ContentResult> GetOwnersAsync()
    {
		var result = await _getOwnerUseCase.HandleAsync();

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
    public async Task<Result> CreateOwnerAsync([Required, FromBody] CreateUserRequest request)
    {
	    var result = await _createOwnerUseCase.HandleAsync(new(request.Name, request.Email, request.Password));
	    
	    return result;
    }

	[HttpPut, Route("edit")]
	public async Task<Result> EditOwnerAsync([Required, FromBody] Requests.EditOwnerRequest request)
	{
		var result = await _editOwnerUseCase.HandleAsync(new(request.OwnerId, request.Name, request.Email, request.Password));

		return result;
	}

	[HttpDelete, Route("delete/{ownerId}")]
	public async Task<Result> DeleteOwnerAsync([Required] Guid ownerId)
	{
		var result = await _deleteOwnerUseCase.HandleAsync(ownerId);

		return result;
	}

	[HttpGet, Route("get/{ownerId}")]
	public async Task<ContentResult> GetOwnerByIdAsync([Required] Guid ownerId)
	{
		var result = await _getOwnerByIdUseCase.HandleAsync(ownerId);

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
