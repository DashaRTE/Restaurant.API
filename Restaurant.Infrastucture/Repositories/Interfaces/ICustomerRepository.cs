using Restaurant.Infrastucture.Entities;

namespace Restaurant.Infrastucture.Repositories.Interfaces;
public interface ICustomerRepository
{
    Task<List<Customer>> GetCustomersAsync();
    Task<Customer> CreateCustomerAsync(string Email, string Name, string Password);
    Task<Customer?> EditCustomerAsync(Guid CustomerId, string Email, string Name, string Password);
    Task DeleteCustomerAsync(Guid CustomerId);
    Task<Customer?> GetCustomerByIdAsync(Guid CustomerId);
    Task<Customer?> GetCustomerOrdersAsync(Guid CustomerId);
}
