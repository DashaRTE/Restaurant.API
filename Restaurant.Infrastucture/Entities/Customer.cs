namespace Restaurant.Infrastucture.Entities;
public class Customer : User 
{
    public ICollection<Order> Orders { get; }
}
