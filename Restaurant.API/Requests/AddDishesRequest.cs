using System.ComponentModel.DataAnnotations;

namespace Restaurant.API.Requests;

public record AddDishesRequest([Required] Guid OrderId, [Required] Guid DishId);
