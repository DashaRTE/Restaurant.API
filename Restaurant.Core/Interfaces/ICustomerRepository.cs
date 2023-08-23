using Restaurant.Core.Dto;

namespace Restaurant.Core.Interfaces;
public interface ICustomerRepository
{
    Task<IList<CustomerDto>> GetCustomersAsync();
    Task<CustomerDto> CreateCustomerAsync(string email, string name, string password);
    Task<CustomerDto?> EditCustomerAsync(Guid customerId, string email, string name, string password);
    Task DeleteCustomerAsync(Guid customerId);
    Task<CustomerDto?> GetCustomerByIdAsync(Guid customerId);
    Task<CustomerDto?> GetCustomerOrdersAsync(Guid customerId);
}
