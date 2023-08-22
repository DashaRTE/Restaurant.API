using Restaurant.Infrastucture.Entities;

namespace Restaurant.Infrastucture.Repositories.Interfaces;
public interface IDishRepository
{
	Task<List<Dish>> GetDishesAsync();
	Task<Dish> CreateDishAsync(string Name);
	Task<Dish> EditDishAsync(Guid DishId, string Name);
	Task DeleteDishAsync(Guid DishId);
	Task<Dish?> GetDishByIdAsync(Guid dishId);
}
