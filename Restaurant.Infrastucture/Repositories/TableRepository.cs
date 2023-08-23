using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Dto;
using Restaurant.Core.Interfaces;
using Restaurant.Infrastucture.Entities;

namespace Restaurant.Infrastucture.Repositories;

public class TableRepository : ITableRepository
{
	private readonly DataContext _dataContext;
	private readonly IMapper _mapper;

	public TableRepository(DataContext context, IMapper mapper)
	{
		_dataContext = context;
		_mapper = mapper;
	}

	public async Task<IList<TableDto>> GetTablesAsync() =>
		_mapper.Map<IList<Table>, IList<TableDto>>(await _dataContext.Tables.ToListAsync());

	public async Task<TableDto?> GetTableByIdAsync(Guid tableId) =>
		_mapper.Map<Table?, TableDto?>(await _dataContext.Tables.FindAsync(tableId));


	public async Task<TableDto?> GetTableOrdersAsync(Guid tableId)
	{
		var table = await _dataContext.Tables.Include(table => table.Orders.Where(order => order.Price > 100))
			.FirstOrDefaultAsync(table => table.Id == tableId);

		return _mapper.Map<Table?, TableDto?>(table);
	}

	public async Task<TableDto> CreateTableAsync(int number)
	{
		var table = new Table { Number = number };

		await _dataContext.Tables.AddAsync(table);

		await _dataContext.SaveChangesAsync();

		return _mapper.Map<Table, TableDto>(table);
	}


	public async Task<TableDto?> EditTableAsync(Guid tableId, int number)
	{
		var table = await _dataContext.Tables.FindAsync(tableId);

		if (table is not null)
		{
			table.Number = number;
			table.ModifiedDate = DateTime.UtcNow;

			_dataContext.Entry(table).State = EntityState.Modified;

			await _dataContext.SaveChangesAsync();
		}

		return _mapper.Map<Table?, TableDto?>(table);
	}

	public async Task DeleteTableAsync(Guid tableId)
	{
		var table = await _dataContext.Tables.FindAsync(tableId);

		if (table is not null)
		{
			_dataContext.Tables.Remove(table);

			await _dataContext.SaveChangesAsync();
		}
	}
}