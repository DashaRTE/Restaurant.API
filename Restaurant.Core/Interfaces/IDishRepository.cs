using Restaurant.Core.Dto;

namespace Restaurant.Core.Interfaces;
public interface IDishRepository
{
	Task<IList<DishDto>> GetDishesAsync();
	Task<DishDto> CreateDishAsync(string name);
	Task<DishDto> EditDishAsync(Guid dishId, string name);
	Task DeleteDishAsync(Guid dishId);
	Task<DishDto?> GetDishByIdAsync(Guid dishId);
}
