using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Dto;
using Restaurant.Core.Interfaces;
using Restaurant.Infrastucture.Entities;

namespace Restaurant.Infrastucture.Repositories;

public class DishRepository : IDishRepository
{
	private readonly DataContext _dataContext;
	private readonly IMapper _mapper;

	public DishRepository(DataContext context, IMapper mapper)
	{
		_dataContext = context;
		_mapper = mapper;
	}

	public async Task<IList<DishDto>> GetDishesAsync() =>
		_mapper.Map<IList<Dish>, IList<DishDto>>(await _dataContext.Dishes.ToListAsync());

	public async Task<DishDto?> GetDishByIdAsync(Guid dishId) =>
		_mapper.Map<Dish?, DishDto?>(await _dataContext.Dishes.FindAsync(dishId));

	public async Task<DishDto> CreateDishAsync(string name)
	{
		var dish = new Dish() { Name = name };

		await _dataContext.Dishes.AddAsync(dish);

		await _dataContext.SaveChangesAsync();

		return _mapper.Map<Dish, DishDto>(dish);
	}

	public async Task<DishDto> EditDishAsync(Guid dishId, string name)
	{
		var dish = await _dataContext.Dishes.FindAsync(dishId);

		if (dish is not null)
		{
			dish.Name = name;
			dish.ModifiedDate = DateTime.UtcNow;

			_dataContext.Entry(dish).State = EntityState.Modified;

			await _dataContext.SaveChangesAsync();
		}

		return _mapper.Map<Dish?, DishDto>(dish);
	}

	public async Task DeleteDishAsync(Guid dishId)
	{
		var dish = await _dataContext.Dishes.FindAsync(dishId);

		if (dish is not null)
		{
			_dataContext.Dishes.Remove(dish);

			await _dataContext.SaveChangesAsync();
		}
	}
}