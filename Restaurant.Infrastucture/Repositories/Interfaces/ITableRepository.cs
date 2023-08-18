namespace Restaurant.Infrastucture.Repositories.Interfaces;
public interface ITableRepository
{
    Task<List<Entities.Table>> GetTablesAsync();
    Task<Entities.Table> CreateTableAsync(int Number);
    Task<Entities.Table?> EditTableAsync(Guid TableId, int Number);
    Task DeleteTableAsync(Guid TableId);
    Task<Entities.Table?> GetTableByIdAsync(Guid TableId);
    Task<Entities.Table?> GetTableOrdersAsync(Guid TableId);
}
