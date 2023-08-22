using Microsoft.EntityFrameworkCore;
using Restaurant.Infrastucture.Entities;
using Restaurant.Infrastucture.Repositories.Interfaces;

namespace Restaurant.Infrastucture.Repositories;
public class DishRepository : IDishRepository
{
	private readonly DataContext _dataContext;
	public DishRepository(DataContext context)
	{
		_dataContext = context;
	}

	public async Task<List<Dish>> GetDishesAsync()
	{
		return await _dataContext.Dishes.ToListAsync();
	}

	public async Task<Dish> CreateDishAsync(string Name)
	{
		var dish = new Dish() { Name = Name };
		await _dataContext.Dishes.AddAsync(dish);
		await _dataContext.SaveChangesAsync();
		return dish;
	}

	public async Task<Dish> EditDishAsync(Guid DishId, string Name)
	{
		var dish = await _dataContext.Dishes.FindAsync(DishId);
		if (dish is not null)
		{
			dish.Name = Name;
			dish.ModifiedDate = DateTime.UtcNow;

			_dataContext.Entry(dish).State = EntityState.Modified;

			await _dataContext.SaveChangesAsync();
		}

		return dish;
	}

	public async Task DeleteDishAsync(Guid DishId)
	{
		var dish = await _dataContext.Dishes.FindAsync(DishId);
		if (dish is not null)
		{
			_dataContext.Dishes.Remove(dish);
			await _dataContext.SaveChangesAsync();
		}
	}

	public async Task<Dish?> GetDishByIdAsync(Guid dishId)
	{
		var dish = await _dataContext.Dishes.FindAsync(dishId);

		if (dish is not null)
		{
			return dish;
		}

		return null;
	}
}
