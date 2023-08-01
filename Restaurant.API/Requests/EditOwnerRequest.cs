using System.ComponentModel.DataAnnotations;

namespace Restaurant.API.Requests;

public record EditOwnerRequest([Required] Guid OwnerId, [Required] string Email, [Required] string Name, [Required] string Password);
