using Restaurant.Infrastucture.Entities;

namespace Restaurant.Infrastucture.Repositories.Interfaces;
public interface IChefRepository
{
    Task<List<Chef>> GetChefsAsync();
    Task<Chef> CreateChefAsync(string email, string name, string password);
    Task<Chef?> EditChefAsync(Guid ChefId, string Email, string Name, string Password);
    Task DeleteChefAsync(Guid ChefId);
    Task<Chef?> GetChefByIdAsync(Guid ChefId);
}
