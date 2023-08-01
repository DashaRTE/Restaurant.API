using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Restaurant.Infrastucture.Entities;
using Restaurant.Infrastucture.Repositories.Interfaces;

namespace Restaurant.Infrastucture.Repositories;
public class TableRepository : ITableRepository
{
    private readonly DataContext _dataContext;
    public TableRepository(DataContext context)
    {
        _dataContext = context;
    }
    public async Task<List<Entities.Table>> GetTablesAsync()
    {
        return await _dataContext.Tables.ToListAsync();
    }
    public async Task<Entities.Table> CreateTableAsync(int Number)
    {
        var table = new Entities.Table() { Number = Number };
        await _dataContext.Tables.AddAsync(table);
        await _dataContext.SaveChangesAsync();
        return table;
    }
    public async Task<Entities.Table?> EditTableAsync(Guid TableId, int Number)
    {
        var table = await _dataContext.Tables.FindAsync(TableId);
        if (table is not null)
        {
            table.Number = Number;
            table.ModifiedDate = DateTime.UtcNow;
            await _dataContext.SaveChangesAsync();
        }
        return table;
    }
    public async Task DeleteTableAsync(Guid TableId)
    {
        var table = await _dataContext.Tables.FindAsync(TableId);
        if (table is not null)
        {
            _dataContext.Tables.Remove(table);
            await _dataContext.SaveChangesAsync();
        }
    }
    public async Task<Entities.Table?> GetTableByIdAsync(Guid TableId)
    {
        var table = await _dataContext.Tables.FindAsync(TableId);
        if (table is not null)
        {
            return table;
        }
        return null;
    }
}
