using System.ComponentModel.DataAnnotations;

namespace Restaurant.API.Requests;

public record CreateOrderRequest([Required] int Number, [Required] decimal Price, [Required] Guid ChefId, [Required] Guid CustomerId, [Required] Guid WaiterId, [Required] Guid TableId);
