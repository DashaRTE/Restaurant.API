namespace Restaurant.Infrastucture.Entities;
public class Order : Entity 
{
    public int Number { get; set; }
    public decimal Price { get; set; }
    public Guid ChefId { get; set; }
    public Guid CustomerId { get; set; }
    public Guid WaiterId { get; set; }
    public Guid TableId { get; set; }

    public Chef Chef { get; set; }
    public Customer Customer { get; set; }
    public Waiter Waiter { get; set; }
    public Table Table { get; set; }
}
