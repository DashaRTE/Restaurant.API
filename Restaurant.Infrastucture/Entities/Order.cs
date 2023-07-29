using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Restaurant.Infrastucture.Entities;
public class Order : Entity 
{
    public int Number { get; set; }
    public decimal Price { get; set; }
    public string ChefId { get; set; }
    public string CustomerId { get; set; }
    public string WaiterId { get; set; }
    public string TableId { get; set; }

    public Chef Chef { get; set; }
    public Customer Customer { get; set; }
    public Waiter Waiter { get; set; }
    public Table Table { get; set; }
}
