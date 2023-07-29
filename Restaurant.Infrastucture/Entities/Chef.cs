namespace Restaurant.Infrastucture.Entities;
public class Chef : User 
{
    public ICollection<Order> Orders { get; }
}
