using Restaurant.Core.Dto;

namespace Restaurant.Core.Interfaces;
public interface IOwnerRepository
{
    Task<IList<OwnerDto>> GetOwnersAsync();
    Task<OwnerDto> CreateOwnerAsync(string email, string name, string password);
    Task<OwnerDto?> EditOwnerAsync(Guid ownerId, string email, string name, string password);
    Task DeleteOwnerAsync(Guid ownerId);
    Task<OwnerDto?> GetOwnerByIdAsync(Guid ownerId);
}
