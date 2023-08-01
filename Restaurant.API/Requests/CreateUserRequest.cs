using System.ComponentModel.DataAnnotations;

namespace Restaurant.API.Requests;

public record CreateUserRequest([Required] string Email, [Required] string Name, [Required] string Password);
