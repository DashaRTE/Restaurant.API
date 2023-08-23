using Restaurant.Core.Dto;

namespace Restaurant.Core.Interfaces;
public interface IOrderRepository
{
    Task<IList<OrderDto>> GetOrdersAsync();
    Task<OrderDto?> CreateOrderAsync(int number, decimal price, Guid chefId, Guid customerId, Guid waiterId, Guid tableId);
    Task<OrderDto?> EditOrderAsync(Guid orderId, int number, decimal price, Guid chefId, Guid customerId, Guid waiterId, Guid tableId);
    Task<OrderDto?> GetOrderByIdAsync(Guid orderId);
    Task AddDishesAsync(Guid orderId, Guid dishId);
    Task RemoveDishesAsync(Guid orderId, Guid dishId);
}
