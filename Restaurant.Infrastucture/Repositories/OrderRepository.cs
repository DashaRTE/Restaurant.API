using Microsoft.EntityFrameworkCore;
using Restaurant.Infrastucture.Entities;
using Restaurant.Infrastucture.Repositories.Interfaces;

namespace Restaurant.Infrastucture.Repositories;
public class OrderRepository : IOrderRepository
{
    private readonly DataContext _dataContext;
    public OrderRepository(DataContext context)
    {
        _dataContext = context;
    }
    public async Task<List<Order>> GetOrdersAsync()
    {
        return await _dataContext.Orders.ToListAsync();
    }

    public async Task<Order?> CreateOrderAsync(int Number, decimal Price, Guid ChefId, Guid CustomerId, Guid WaiterId, Guid TableId)
    {
        var chef = await _dataContext.Chefs.FindAsync(ChefId);

        if (chef is null) 
        {
            return null;
        }

        var customer = await _dataContext.Customers.FindAsync(CustomerId);

        if (customer is null)
        {
            return null;
        }

        var waiter = await _dataContext.Waiters.FindAsync(WaiterId);

        if (waiter is null)
        {
            return null;
        }

        var table = await _dataContext.Tables.FindAsync(TableId);

        if (table is null)
        {
            return null;
        }

        var order = new Order() { Number = Number, Price = Price, ChefId = ChefId, CustomerId = CustomerId, WaiterId = WaiterId, TableId = TableId };
        await _dataContext.Orders.AddAsync(order);
        await _dataContext.SaveChangesAsync();
        return order;
    }
    public async Task<Order?> EditOrderAsync(Guid OrderId, int Number, decimal Price, Guid ChefId, Guid CustomerId, Guid WaiterId, Guid TableId)
    {
        var chef = await _dataContext.Chefs.FindAsync(ChefId);

        if (chef is null)
        {
            return null;
        }

        var customer = await _dataContext.Customers.FindAsync(CustomerId);

        if (customer is null)
        {
            return null;
        }

        var waiter = await _dataContext.Waiters.FindAsync(WaiterId);

        if (waiter is null)
        {
            return null;
        }

        var table = await _dataContext.Tables.FindAsync(TableId);

        if (table is null)
        {
            return null;
        }

        var order = await _dataContext.Orders.FindAsync(OrderId);

        if (order is not null)
        {
            order.Number = Number;
            order.Price = Price;
            order.ChefId = ChefId;
            order.CustomerId = CustomerId;
            order.WaiterId = WaiterId;
            order.TableId = TableId;
            order.ModifiedDate = DateTime.UtcNow;
            await _dataContext.SaveChangesAsync();
        }
        return order;
    }
    public async Task<Order?> GetOrderByIdAsync(Guid OrderId)
    {
        var order = await _dataContext.Orders.FindAsync(OrderId);
        if (order is not null)
        {
            return order;
        }
        return null;
    }
}
