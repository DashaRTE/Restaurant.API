namespace Restaurant.API.Responses;

public record CustomerOrdersResponse(Guid CustomerId, string Email, string Name, string Password, IList<CustomerOrderResponse> Orders);

public record CustomerOrderResponse(int Number, decimal Price);
