namespace Restaurant.Core.UseCases.Waiter.Edit;

public record EditWaiterRequest(Guid WaiterId, string Name, string Email, string Password);
