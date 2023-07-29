namespace Restaurant.Infrastucture.Entities;
public class Owner : User 
{
    public ICollection<Order> Orders { get; }
}
