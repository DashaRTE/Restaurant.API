using System.ComponentModel.DataAnnotations;

namespace Restaurant.API.Requests;

public record EditCustomerRequest([Required] Guid CustomerId, [Required] string Email, [Required] string Name, [Required] string Password);
