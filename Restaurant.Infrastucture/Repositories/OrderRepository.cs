using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Dto;
using Restaurant.Core.Interfaces;
using Restaurant.Infrastucture.Entities;

namespace Restaurant.Infrastucture.Repositories;

public class OrderRepository : IOrderRepository
{
	private readonly DataContext _dataContext;
	private readonly IMapper _mapper;

	public OrderRepository(DataContext context, IMapper mapper)
	{
		_dataContext = context;
		_mapper = mapper;
	}

	public async Task<IList<OrderDto>> GetOrdersAsync() =>
		_mapper.Map<IList<Order>, IList<OrderDto>>(await _dataContext.Orders.ToListAsync());

	public async Task<OrderDto?> GetOrderByIdAsync(Guid orderId) =>
		_mapper.Map<Order?, OrderDto?>(await _dataContext.Orders.FindAsync(orderId));

	public async Task<OrderDto?> CreateOrderAsync(int number, decimal price, Guid chefId, Guid customerId, Guid waiterId, Guid tableId)
	{
		var chef = await _dataContext.Chefs.FindAsync(chefId);

		if (chef is null)
		{
			return null;
		}

		var customer = await _dataContext.Customers.FindAsync(customerId);

		if (customer is null)
		{
			return null;
		}

		var waiter = await _dataContext.Waiters.FindAsync(waiterId);

		if (waiter is null)
		{
			return null;
		}

		var table = await _dataContext.Tables.FindAsync(tableId);

		if (table is null)
		{
			return null;
		}

		var order = new Order
		{
			Number = number,
			Price = price,
			ChefId = chefId,
			CustomerId = customerId,
			WaiterId = waiterId,
			TableId = tableId
		};

		await _dataContext.Orders.AddAsync(order);

		await _dataContext.SaveChangesAsync();

		return _mapper.Map<Order, OrderDto>(order);
	}

	public async Task AddDishesAsync(Guid orderId, Guid dishId)
	{
		var order = await _dataContext.Orders.AsTracking()
			.Include(static order => order.Dishes)
			.FirstOrDefaultAsync(order => order.Id == orderId);

		if (order is not null)
		{
			var dish = await _dataContext.Dishes.FindAsync(dishId);

			if (dish is not null)
			{
				order.Dishes.Add(dish);
			}

			await _dataContext.SaveChangesAsync();
		}
	}

	public async Task RemoveDishesAsync(Guid orderId, Guid dishId)
	{
		var order = await _dataContext.Orders.AsTracking()
			.Include(static order => order.Dishes)
			.FirstOrDefaultAsync(order => order.Id == orderId);

		if (order is not null)
		{
			var dish = await _dataContext.Dishes.FindAsync(dishId);

			if (dish is not null)
			{
				order.Dishes.Remove(dish);
			}

			await _dataContext.SaveChangesAsync();
		}
	}

	public async Task<OrderDto?> EditOrderAsync(Guid orderId, int number, decimal price, Guid chefId, Guid customerId,
		Guid waiterId, Guid tableId)
	{
		var chef = await _dataContext.Chefs.FindAsync(chefId);

		if (chef is null)
		{
			return null;
		}

		var customer = await _dataContext.Customers.FindAsync(customerId);

		if (customer is null)
		{
			return null;
		}

		var waiter = await _dataContext.Waiters.FindAsync(waiterId);

		if (waiter is null)
		{
			return null;
		}

		var table = await _dataContext.Tables.FindAsync(tableId);

		if (table is null)
		{
			return null;
		}

		var order = await _dataContext.Orders.FindAsync(orderId);

		if (order is not null)
		{
			order.Number = number;
			order.Price = price;
			order.ChefId = chefId;
			order.CustomerId = customerId;
			order.WaiterId = waiterId;
			order.TableId = tableId;
			order.ModifiedDate = DateTime.UtcNow;

			_dataContext.Entry(order).State = EntityState.Modified;

			await _dataContext.SaveChangesAsync();
		}

		return _mapper.Map<Order?, OrderDto?>(order);
	}
}