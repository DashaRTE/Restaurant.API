namespace Restaurant.Core.UseCases.Order.AddDishes;

public record AddDishesRequest(Guid OrderId, Guid DishId);
