using System.ComponentModel.DataAnnotations;

namespace Restaurant.API.Requests;

public record EditTableRequest([Required] Guid TableId, [Required] int Number);
