namespace Restaurant.Core.UseCases.Customer;

public record CreateCustomerRequest(string Name, string Email, string Password);
