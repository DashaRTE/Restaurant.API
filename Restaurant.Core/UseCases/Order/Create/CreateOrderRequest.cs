namespace Restaurant.Core.UseCases.Order.Create;

public record CreateOrderRequest(int Number, decimal Price, Guid ChefId, Guid CustomerId, Guid WaiterId, Guid TableId);
