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

	public async Task<Dish> CreateDishAsync(string Name, decimal Price)
	{
		var dish = new Dish() { Name = Name, Price = Price };
		await _dataContext.Dishes.AddAsync(dish);
		await _dataContext.SaveChangesAsync();
		return dish;
	}

	public async Task<Dish> EditDishAsync(Guid DishId, string Name, decimal Price)
	{
		var dish = await _dataContext.Dishes.FindAsync(DishId);
		if (dish is not null)
		{
			dish.Name = Name;
			dish.Price = Price;
			dish.ModifiedDate = DateTime.UtcNow;
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
}
