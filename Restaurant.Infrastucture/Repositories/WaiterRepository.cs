using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Dto;
using Restaurant.Core.Interfaces;
using Restaurant.Infrastucture.Entities;

namespace Restaurant.Infrastucture.Repositories;

public class WaiterRepository : IWaiterRepository
{
	private readonly DataContext _dataContext;
	private readonly IMapper _mapper;

	public WaiterRepository(DataContext context, IMapper mapper)
	{
		_dataContext = context;
		_mapper = mapper;
	}

	public async Task<IList<WaiterDto>> GetWaitersAsync() =>
		_mapper.Map<IList<Waiter>, IList<WaiterDto>>(await _dataContext.Waiters.ToListAsync());

	public async Task<WaiterDto?> GetWaiterByIdAsync(Guid waiterId) =>
		_mapper.Map<Waiter?, WaiterDto?>(await _dataContext.Waiters.FindAsync(waiterId));

	public async Task<WaiterDto> CreateWaiterAsync(string email, string name, string password)
	{
		var waiter = new Waiter { Email = email, Name = name, Password = password };

		await _dataContext.Waiters.AddAsync(waiter);

		await _dataContext.SaveChangesAsync();

		return _mapper.Map<Waiter, WaiterDto>(waiter);
	}

	public async Task<WaiterDto?> EditWaiterAsync(Guid waiterId, string email, string name, string password)
	{
		var waiter = await _dataContext.Waiters.FindAsync(waiterId);

		if (waiter is not null)
		{
			waiter.Email = email;
			waiter.Name = name;
			waiter.Password = password;
			waiter.ModifiedDate = DateTime.UtcNow;

			_dataContext.Entry(waiter).State = EntityState.Modified;

			await _dataContext.SaveChangesAsync();
		}

		return _mapper.Map<Waiter?, WaiterDto?>(waiter);
	}

	public async Task DeleteWaiterAsync(Guid waiterId)
	{
		var waiter = await _dataContext.Waiters.FindAsync(waiterId);

		if (waiter is not null)
		{
			_dataContext.Waiters.Remove(waiter);

			await _dataContext.SaveChangesAsync();
		}
	}
}