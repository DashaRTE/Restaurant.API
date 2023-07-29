namespace Restaurant.Infrastucture.Entities;
public class Waiter : User 
{
    public ICollection<Order> Orders { get; }
}
