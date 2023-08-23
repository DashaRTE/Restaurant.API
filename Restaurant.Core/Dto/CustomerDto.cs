namespace Restaurant.Core.Dto;

public class CustomerDto : UserDto
{
	public IList<OrderDto> Orders { get; set; }
}
