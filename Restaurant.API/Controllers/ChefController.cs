using Microsoft.AspNetCore.Mvc;
using Restaurant.API.Requests;
using Restaurant.Infrastucture.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.API.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/chef")]

public class ChefController : ControllerBase
{
    private readonly IChefRepository _chefRepository;
    public ChefController(IChefRepository chefRepository)
    {
        _chefRepository = chefRepository;
    }

    [HttpGet, Route("get")]
    public async Task<IActionResult> GetChefsAsync()
    {
        var chefs = await _chefRepository.GetChefsAsync();
        return Ok(chefs);
    }

    [HttpPost, Route("create")]
    public async Task<IActionResult> CreateChefAsync([Required, FromBody] CreateUserRequest Request)
    {
        var chef = await _chefRepository.CreateChefAsync(Request.Email, Request.Name, Request.Password);
        return Ok(chef);
    }
    [HttpPut, Route("edit")]
    public async Task<IActionResult> EditChefAsync([Required, FromBody] EditChefRequest Request)
    {
        var chef = await _chefRepository.EditChefAsync(Request.ChefId, Request.Email, Request.Name, Request.Password);
        return Ok(chef);
    }
    [HttpDelete, Route("delete/{chefId}")]
    public async Task<IActionResult> DeleteChefAsync([Required] Guid chefId)
    {
        await _chefRepository.DeleteChefAsync(chefId);
        return Ok();
    }
    [HttpGet, Route("get/{chefId}")]
    public async Task<IActionResult> GetChefByIdAsync([Required] Guid chefId)
    {
        var chef = await _chefRepository.GetChefByIdAsync(chefId);
        if (chef is null)
        {
            return NotFound();
        }
        return Ok(chef);
    }
}
