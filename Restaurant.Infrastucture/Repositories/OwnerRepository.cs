using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Dto;
using Restaurant.Core.Interfaces;
using Restaurant.Infrastucture.Entities;

namespace Restaurant.Infrastucture.Repositories;

public class OwnerRepository : IOwnerRepository
{
	private readonly DataContext _dataContext;
	private readonly IMapper _mapper;

	public OwnerRepository(DataContext context, IMapper mapper)
	{
		_dataContext = context;
		_mapper = mapper;
	}

	public async Task<IList<OwnerDto>> GetOwnersAsync() =>
		_mapper.Map<IList<Owner>, IList<OwnerDto>>(await _dataContext.Owners.ToListAsync());

	public async Task<OwnerDto?> GetOwnerByIdAsync(Guid ownerId) =>
		_mapper.Map<Owner?, OwnerDto?>(await _dataContext.Owners.FindAsync(ownerId));

	public async Task<OwnerDto> CreateOwnerAsync(string email, string name, string password)
	{
		var owner = new Owner { Email = email, Name = name, Password = password };

		await _dataContext.Owners.AddAsync(owner);

		await _dataContext.SaveChangesAsync();

		return _mapper.Map<Owner, OwnerDto>(owner);
	}

	public async Task<OwnerDto?> EditOwnerAsync(Guid ownerId, string email, string name, string password)
	{
		var owner = await _dataContext.Owners.FindAsync(ownerId);

		if (owner is not null)
		{
			owner.Email = email;
			owner.Name = name;
			owner.Password = password;
			owner.ModifiedDate = DateTime.UtcNow;

			_dataContext.Entry(owner).State = EntityState.Modified;

			await _dataContext.SaveChangesAsync();
		}

		return _mapper.Map<Owner?, OwnerDto?>(owner);
	}

	public async Task DeleteOwnerAsync(Guid ownerId)
	{
		var owner = await _dataContext.Owners.FindAsync(ownerId);

		if (owner is not null)
		{
			_dataContext.Owners.Remove(owner);

			await _dataContext.SaveChangesAsync();
		}
	}
}