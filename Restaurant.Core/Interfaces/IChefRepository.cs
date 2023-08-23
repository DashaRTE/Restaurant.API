using Restaurant.Core.Dto;

namespace Restaurant.Core.Interfaces;
public interface IChefRepository
{
    Task<IList<ChefDto>> GetChefsAsync();
    Task<ChefDto> CreateChefAsync(string email, string name, string password);
    Task<ChefDto?> EditChefAsync(Guid chefId, string email, string name, string password);
    Task DeleteChefAsync(Guid chefId);
    Task<ChefDto?> GetChefByIdAsync(Guid chefId);
}
