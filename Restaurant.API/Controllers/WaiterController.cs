using Microsoft.AspNetCore.Mvc;
using Restaurant.API.Requests;
using Restaurant.Infrastucture.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.API.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/waiter")]

public class WaiterController :ControllerBase
{
    private readonly IWaiterRepository _waiterRepository;
    public WaiterController(IWaiterRepository waiterRepository)
    {
        _waiterRepository = waiterRepository;
    }

    [HttpGet, Route("get")]
    public async Task<IActionResult> GetWaitersAsync()
    {
        var waiters = await _waiterRepository.GetWaitersAsync();
        return Ok(waiters);
    }

    [HttpPost, Route("create")]
    public async Task<IActionResult> CreateWaiterAsync([Required, FromBody] CreateUserRequest Request)
    {
        var waiter = await _waiterRepository.CreateWaiterAsync(Request.Email, Request.Name, Request.Password);
        return Ok(waiter);
    }
    [HttpPut, Route("edit")]
    public async Task<IActionResult> EditWaiterAsync([Required, FromBody] EditWaiterRequest Request)
    {
        var waiter = await _waiterRepository.EditWaiterAsync(Request.WaiterId, Request.Email, Request.Name, Request.Password);
        return Ok(waiter);
    }
    [HttpDelete, Route("delete/{waiterId}")]
    public async Task<IActionResult> DeleteWaiterAsync([Required] Guid waiterId)
    {
        await _waiterRepository.DeleteWaiterAsync(waiterId);
        return Ok();
    }
    [HttpGet, Route("get/{waiterId}")]
    public async Task<IActionResult> GetWaiterByIdAsync([Required] Guid waiterId)
    {
        var waiter = await _waiterRepository.GetWaiterByIdAsync(waiterId);
        if (waiter is null)
        {
            return NotFound();
        }
        return Ok(waiter);
    }
}
