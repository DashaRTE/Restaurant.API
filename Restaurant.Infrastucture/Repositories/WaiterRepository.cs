using Microsoft.EntityFrameworkCore;
using Restaurant.Infrastucture.Entities;
using Restaurant.Infrastucture.Repositories.Interfaces;

namespace Restaurant.Infrastucture.Repositories;
public class WaiterRepository : IWaiterRepository
{
    private readonly DataContext _dataContext;
    public WaiterRepository(DataContext context)
    {
        _dataContext = context;
    }

    public async Task<List<Waiter>> GetWaitersAsync()
    {
        return await _dataContext.Waiters.ToListAsync();
    }

    public async Task<Waiter> CreateWaiterAsync(string Email, string Name, string Password)
    {
        var waiter = new Waiter() { Email = Email, Name = Name, Password = Password };
        await _dataContext.Waiters.AddAsync(waiter);
        await _dataContext.SaveChangesAsync();
        return waiter;
    }

    public async Task<Waiter?> EditWaiterAsync(Guid WaiterId, string Email, string Name, string Password)
    {
        var waiter = await _dataContext.Waiters.FindAsync(WaiterId);
        if (waiter is not null)
        {
            waiter.Email = Email;
            waiter.Name = Name;
            waiter.Password = Password;
            waiter.ModifiedDate = DateTime.UtcNow;
            await _dataContext.SaveChangesAsync();
        }
        return waiter;
    }

    public async Task DeleteWaiterAsync(Guid WaiterId)
    {
        var waiter = await _dataContext.Waiters.FindAsync(WaiterId);
        if (waiter is not null)
        {
            _dataContext.Waiters.Remove(waiter);
            await _dataContext.SaveChangesAsync();
        }
    }

    public async Task<Waiter?> GetWaiterByIdAsync(Guid WaiterId)
    {
        var waiter = await _dataContext.Waiters.FindAsync(WaiterId);
        if (waiter is not null)
        {
            return waiter;
        }
        return null;
    }
}
