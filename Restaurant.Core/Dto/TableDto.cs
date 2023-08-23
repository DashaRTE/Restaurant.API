namespace Restaurant.Core.Dto;
public class TableDto : EntityDto
{
	public int Number { get; set; }
	public IList<OrderDto> Orders { get; set; }
}
