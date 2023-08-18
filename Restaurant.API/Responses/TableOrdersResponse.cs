namespace Restaurant.API.Responses;

public record TableOrdersResponse(int Number, IList<TableOrderResponse> Order);
public record TableOrderResponse(int Number, decimal Price);
