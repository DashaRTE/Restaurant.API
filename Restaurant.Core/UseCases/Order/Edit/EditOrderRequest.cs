namespace Restaurant.Core.UseCases.Order.Edit;
public record EditOrderRequest(Guid OrderId, int Number, decimal Price, Guid ChefId, Guid CustomerId, Guid WaiterId, Guid TableId);