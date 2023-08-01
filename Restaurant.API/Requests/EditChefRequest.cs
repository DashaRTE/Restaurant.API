using System.ComponentModel.DataAnnotations;

namespace Restaurant.API.Requests;

public record EditChefRequest([Required] Guid ChefId, [Required] string Email, [Required] string Name, [Required] string Password);
