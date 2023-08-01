using System.ComponentModel.DataAnnotations;

namespace Restaurant.API.Requests;

public record EditWaiterRequest([Required] Guid WaiterId, [Required] string Email, [Required] string Name, [Required] string Password);
