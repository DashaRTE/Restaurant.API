namespace Restaurant.Core.UseCases.Owner.Edit;

public record EditOwnerRequest(Guid OwnerId, string Name, string Email, string Password);
