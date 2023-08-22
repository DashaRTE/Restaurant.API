namespace Restaurant.Core.UseCases.Chef.Edit;
public record EditChefRequest(Guid ChefId, string Name, string Email, string Password);