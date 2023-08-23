using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Dto;
using Restaurant.Core.Interfaces;
using Restaurant.Infrastucture.Entities;

namespace Restaurant.Infrastucture.Repositories;

public class ChefRepository : IChefRepository
{
	private readonly DataContext _dataContext;
	private readonly IMapper _mapper;

	public ChefRepository(DataContext context, IMapper mapper)
	{
		_dataContext = context;
		_mapper = mapper;
	}

	public async Task<IList<ChefDto>> GetChefsAsync() =>
		_mapper.Map<IList<Chef>, IList<ChefDto>>(await _dataContext.Chefs.ToListAsync());

	public async Task<ChefDto?> GetChefByIdAsync(Guid chefId) =>
		_mapper.Map<Chef?, ChefDto?>(await _dataContext.Chefs.FindAsync(chefId));

	public async Task<ChefDto> CreateChefAsync(string email, string name, string password)
	{
		var chef = new Chef { Email = email, Name = name, Password = password };

		await _dataContext.Chefs.AddAsync(chef);

		await _dataContext.SaveChangesAsync();

		return _mapper.Map<Chef, ChefDto>(chef);
	}

	public async Task<ChefDto?> EditChefAsync(Guid chefId, string email, string name, string password)
	{
		var chef = await _dataContext.Chefs.FindAsync(chefId);

		if (chef is not null)
		{
			chef.Email = email;
			chef.Name = name;
			chef.Password = password;
			chef.ModifiedDate = DateTime.UtcNow;

			_dataContext.Entry(chef).State = EntityState.Modified;

			await _dataContext.SaveChangesAsync();
		}

		return _mapper.Map<Chef?, ChefDto?>(chef);
	}

	public async Task DeleteChefAsync(Guid chefId)
	{
		var chef = await _dataContext.Chefs.FindAsync(chefId);

		if (chef is not null)
		{
			_dataContext.Chefs.Remove(chef);

			await _dataContext.SaveChangesAsync();
		}
	}
}