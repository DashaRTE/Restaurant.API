using Microsoft.EntityFrameworkCore;
using Restaurant.Infrastucture.Entities;
using Restaurant.Infrastucture.Repositories.Interfaces;

namespace Restaurant.Infrastucture.Repositories;
public class OwnerRepository : IOwnerRepository
{
    private readonly DataContext _dataContext;
    public OwnerRepository(DataContext context)
    {
        _dataContext = context;
    }
    public async Task<List<Owner>> GetOwnersAsync()
    {
        return await _dataContext.Owners.ToListAsync();
    }
    public async Task<Owner> CreateOwnerAsync(string Email, string Name, string Password)
    {
        var owner = new Owner() { Email = Email, Name = Name, Password = Password };
        await _dataContext.Owners.AddAsync(owner);
        await _dataContext.SaveChangesAsync();
        return owner;
    }
    public async Task<Owner?> EditOwnerAsync(Guid OwnerId, string Email, string Name, string Password)
    {
        var owner = await _dataContext.Owners.FindAsync(OwnerId);
        if (owner is not null)
        {
            owner.Email = Email;
            owner.Name = Name;
            owner.Password = Password;
            owner.ModifiedDate = DateTime.UtcNow;
            await _dataContext.SaveChangesAsync();
        }
        return owner;
    }
    public async Task DeleteOwnerAsync(Guid OwnerId)
    {
        var owner = await _dataContext.Owners.FindAsync(OwnerId);
        if (owner is not null)
        {
            _dataContext.Owners.Remove(owner);
            await _dataContext.SaveChangesAsync();
        }
    }
    public async Task<Owner?> GetOwnerByIdAsync(Guid OwnerId)
    {
        var owner = await _dataContext.Owners.FindAsync(OwnerId);
        if (owner is not null)
        {
            return owner;
        }
        return null;
    }
}
