using Restaurant.Infrastucture.Entities;

namespace Restaurant.Infrastucture.Repositories.Interfaces;
public interface IWaiterRepository
{
    Task<List<Waiter>> GetWaitersAsync();
    Task<Waiter> CreateWaiterAsync(string Email, string Name, string Password);
    Task<Waiter?> EditWaiterAsync(Guid WaiterId, string Email, string Name, string Password);
    Task DeleteWaiterAsync(Guid WaiterId);
    Task<Waiter?> GetWaiterByIdAsync(Guid WaiterId);
}
