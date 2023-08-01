using Microsoft.AspNetCore.Mvc;
using Restaurant.API.Requests;
using Restaurant.Infrastucture.Entities;
using Restaurant.Infrastucture.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.API.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/owner")]

public class OwnerController : ControllerBase
{
    private readonly IOwnerRepository _ownerRepository;
    public OwnerController(IOwnerRepository ownerRepository)
    {
        _ownerRepository = ownerRepository;
    }

    [HttpGet, Route("get")]
    public async Task<IActionResult> GetOwnersAsync()
    {
        var owners = await _ownerRepository.GetOwnersAsync();
        return Ok(owners);
    }

    [HttpPost, Route("create")]
    public async Task<IActionResult> CreateOwnerAsync([Required, FromBody] CreateUserRequest Request)
    {
        var owner = await _ownerRepository.CreateOwnerAsync(Request.Email, Request.Name, Request.Password);
        return Ok(owner);
    }
    [HttpPut, Route("edit")]
    public async Task<IActionResult> EditOwnerAsync([Required, FromBody] EditOwnerRequest Request)
    {
        var owner = await _ownerRepository.EditOwnerAsync(Request.OwnerId, Request.Email, Request.Name, Request.Password);
        return Ok(owner);
    }
    [HttpDelete, Route("delete/{ownerId}")]
    public async Task<IActionResult> DeleteOwnerAsync([Required] Guid ownerId)
    {
        await _ownerRepository.DeleteOwnerAsync(ownerId);
        return Ok();
    }
    [HttpGet, Route("get/{ownerId}")]
    public async Task<IActionResult> GetOwnerByIdAsync([Required] Guid ownerId)
    {
        var owner = await _ownerRepository.GetOwnerByIdAsync(ownerId);
        if (owner is null)
        {
            return NotFound();
        }
        return Ok(owner);
    }
}
