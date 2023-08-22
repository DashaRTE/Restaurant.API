using Microsoft.AspNetCore.Mvc;
using Restaurant.API.Requests;
using Restaurant.Core;
using Restaurant.Core.UseCases.Chef.Create;
using Restaurant.Core.UseCases.Chef.Delete;
using Restaurant.Core.UseCases.Chef.Edit;
using Restaurant.Core.UseCases.Chef.Get;
using Restaurant.Core.UseCases.Chef.GetById;
using Restaurant.Infrastucture.Entities;
using System.ComponentModel.DataAnnotations;
using EditChefRequest = Restaurant.API.Requests.EditChefRequest;

namespace Restaurant.API.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/chef")]

public class ChefController : ControllerBase
{
    private readonly GetChefUseCase _getChefUseCase;
    private readonly CreateChefUseCase _createChefUseCase;
    private readonly EditChefUseCase _editChefUseCase;
    private readonly DeleteChefUseCase _deleteChefUseCase;
    private readonly GetChefByIdUseCase _getChefByIdUseCase;

	public ChefController(GetChefUseCase getChefUseCase, CreateChefUseCase createChefUseCase, EditChefUseCase editChefUseCase, DeleteChefUseCase deleteChefUseCase, GetChefByIdUseCase getChefByIdUseCase)
	{
		_getChefUseCase = getChefUseCase;
		_createChefUseCase = createChefUseCase;
		_editChefUseCase = editChefUseCase;
		_deleteChefUseCase = deleteChefUseCase;
		_getChefByIdUseCase = getChefByIdUseCase;
	}

    [HttpGet, Route("get")]
    public async Task<Result<List<Chef>>> GetChefsAsync()
    {
	    return await _getChefUseCase.HandleAsync();
    }

	[HttpPost, Route("create")]
	public async Task<Result> CreateChefAsync([Required, FromBody] CreateUserRequest request)
	{
		var result = await _createChefUseCase.HandleAsync(new(request.Name, request.Email, request.Password));

		return result;
	}

	[HttpPut, Route("edit")]
	public async Task<Result> EditChefAsync([Required, FromBody] EditChefRequest Request)
	{
		var result = await _editChefUseCase.HandleAsync(new(Request.ChefId, Request.Name, Request.Email, Request.Password));

		return result;
	}

	[HttpDelete, Route("delete/{chefId}")]
	public async Task<Result> DeleteChefAsync([Required] Guid chefId)
	{
		var result = await _deleteChefUseCase.HandleAsync(chefId);

		return result;
	}

	[HttpGet, Route("get/{chefId}")]
	public async Task<Result<Chef>> GetChefByIdAsync([Required] Guid chefId)
	{
		var result = await _getChefByIdUseCase.HandleAsync(chefId);

		return result;
	}
}
