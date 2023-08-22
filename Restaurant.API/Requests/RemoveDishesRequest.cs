using System.ComponentModel.DataAnnotations;

namespace Restaurant.API.Requests;

public record RemoveDishesRequest([Required] Guid OrderId, [Required] Guid DishId);