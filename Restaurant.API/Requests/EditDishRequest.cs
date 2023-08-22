using System.ComponentModel.DataAnnotations;

namespace Restaurant.API.Requests;

public record EditDishRequest([Required] Guid DishId, [Required] string Name);