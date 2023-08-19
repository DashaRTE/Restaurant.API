namespace Restaurant.Core.UseCases.Customer.Edit;
public record EditCustomerRequest(Guid CustomerId, string Name, string Email, string Password);