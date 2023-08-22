using Microsoft.EntityFrameworkCore;
using Restaurant.Infrastucture.Entities;
using Restaurant.Infrastucture.Repositories.Interfaces;

namespace Restaurant.Infrastucture.Repositories;
public class ChefRepository : IChefRepository
{
    private readonly DataContext _dataContext;

    public ChefRepository(DataContext context)
    {
        _dataContext = context;
    }

	public async Task<List<Chef>> GetChefsAsync() => await _dataContext.Chefs.ToListAsync();

	public async Task<Chef> CreateChefAsync(string email, string name, string password)
    {
        var chef = new Chef { Email = email, Name = name, Password = password };

        await _dataContext.Chefs.AddAsync(chef);

        await _dataContext.SaveChangesAsync();

        return chef;
    }

    public async Task<Chef?> EditChefAsync(Guid ChefId, string Email, string Name, string Password)
    {
        var chef = await _dataContext.Chefs.FindAsync(ChefId);

        if (chef is not null)
        {
            chef.Email = Email;
            chef.Name = Name;
            chef.Password = Password;
            chef.ModifiedDate = DateTime.UtcNow;
            await _dataContext.SaveChangesAsync();
        }

        return chef;
    }

    public async Task DeleteChefAsync(Guid ChefId)
    {
        var chef = await _dataContext.Chefs.FindAsync(ChefId);

        if (chef is not null)
        {
            _dataContext.Chefs.Remove(chef);
            await _dataContext.SaveChangesAsync();
        }
    }

    public async Task<Chef?> GetChefByIdAsync(Guid ChefId)
    {
        var chef = await _dataContext.Chefs.FindAsync(ChefId);

        if (chef is not null)
        {
            return chef;
        }

        return null;
    }
}
