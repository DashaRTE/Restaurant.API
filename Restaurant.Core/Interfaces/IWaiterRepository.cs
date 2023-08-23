using Restaurant.Core.Dto;

namespace Restaurant.Core.Interfaces;
public interface IWaiterRepository
{
    Task<IList<WaiterDto>> GetWaitersAsync();
    Task<WaiterDto> CreateWaiterAsync(string email, string name, string password);
    Task<WaiterDto?> EditWaiterAsync(Guid waiterId, string email, string name, string password);
    Task DeleteWaiterAsync(Guid waiterId);
    Task<WaiterDto?> GetWaiterByIdAsync(Guid waiterId);
}
