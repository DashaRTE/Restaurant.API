using Restaurant.Core.Dto;

namespace Restaurant.Core.Interfaces;
public interface ITableRepository
{
    Task<IList<TableDto>> GetTablesAsync();
    Task<TableDto> CreateTableAsync(int number);
    Task<TableDto?> EditTableAsync(Guid tableId, int number);
    Task DeleteTableAsync(Guid tableId);
    Task<TableDto?> GetTableByIdAsync(Guid tableId);
    Task<TableDto?> GetTableOrdersAsync(Guid tableId);
}
