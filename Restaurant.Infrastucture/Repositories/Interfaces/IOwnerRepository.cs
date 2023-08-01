using Restaurant.Infrastucture.Entities;

namespace Restaurant.Infrastucture.Repositories.Interfaces;
public interface IOwnerRepository
{
    Task<List<Owner>> GetOwnersAsync();
    Task<Owner> CreateOwnerAsync(string Email, string Name, string Password);
    Task<Owner?> EditOwnerAsync(Guid OwnerId, string Email, string Name, string Password);
    Task DeleteOwnerAsync(Guid OwnerId);
    Task<Owner?> GetOwnerByIdAsync(Guid OwnerId);
}
