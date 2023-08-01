using Microsoft.AspNetCore.Mvc;
using Restaurant.API.Requests;
using Restaurant.Infrastucture.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.API.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/order")]
public class OrderController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;
    public OrderController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    [HttpGet, Route("get")]
    public async Task<IActionResult> GetOrdersAsync()
    {
        var orders = await _orderRepository.GetOrdersAsync();
        
        return Ok(orders);
    }

    [HttpPost, Route("create")]
    public async Task<IActionResult> CreateOrderAsync([Required, FromBody] CreateOrderRequest Request)
    {
        var order = await _orderRepository.CreateOrderAsync(Request.Number, Request.Price, Request.ChefId, Request.CustomerId, Request.WaiterId, Request.TableId);
        
        return Ok(order);
    }

    [HttpPut, Route("edit")]
    public async Task<IActionResult> EditOrderAsync([Required, FromBody] EditOrderRequest Request)
    {
        var order = await _orderRepository.EditOrderAsync( Request.OrderId, Request.Number, Request.Price, Request.ChefId, Request.CustomerId, Request.WaiterId, Request.TableId);
        
        return Ok(order);
    }

    [HttpGet, Route("get/{orderId}")]
    public async Task<IActionResult> GetOrderByIdAsync([Required] Guid orderId)
    {
        var order = await _orderRepository.GetOrderByIdAsync(orderId);

        if (order is null)
        {
            return NotFound();
        }

        return Ok(order);
    }
}
