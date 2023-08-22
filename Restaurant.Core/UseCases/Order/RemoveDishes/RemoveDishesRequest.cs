namespace Restaurant.Core.UseCases.Order.RemoveDishes;

public record RemoveDishesRequest(Guid OrderId, Guid DishId);
