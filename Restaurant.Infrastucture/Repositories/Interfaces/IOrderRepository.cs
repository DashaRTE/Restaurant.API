using Restaurant.Infrastucture.Entities;

namespace Restaurant.Infrastucture.Repositories.Interfaces;
public interface IOrderRepository
{
    Task<List<Order>> GetOrdersAsync();
    Task<Order?> CreateOrderAsync(int Number, decimal Price, Guid ChefId, Guid CustomerId, Guid WaiterId, Guid TableId);
    Task<Order?> EditOrderAsync(Guid OrderId, int Number, decimal Price, Guid ChefId, Guid CustomerId, Guid WaiterId, Guid TableId);
    Task<Order?> GetOrderByIdAsync(Guid OrderId);
}
