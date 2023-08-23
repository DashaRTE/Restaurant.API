namespace Restaurant.Core.Dto;
public class OrderDto : EntityDto
{
	public int Number { get; set; }
	public decimal Price { get; set; }
	public Guid ChefId { get; set; }
	public Guid CustomerId { get; set; }
	public Guid WaiterId { get; set; }
	public Guid TableId { get; set; }
}
