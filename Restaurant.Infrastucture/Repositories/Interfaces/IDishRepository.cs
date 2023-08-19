using Restaurant.Infrastucture.Entities;

namespace Restaurant.Infrastucture.Repositories.Interfaces;
public interface IDishRepository
{
	Task<List<Dish>> GetDishesAsync();
	Task<Dish> CreateDishAsync(string Name, decimal Price);
	Task<Dish> EditDishAsync(Guid DishId, string Name, decimal Price);
	Task DeleteDishAsync(Guid DishId);
}
