namespace Restaurant.Infrastucture.Entities;
public class Table : Entity 
{
    public int Number { get; set; }
    public ICollection<Order> Orders { get; }
}
