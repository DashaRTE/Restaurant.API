namespace Restaurant.Infrastucture.Entities;

public class Dish:Entity
{

	public string Name { get; set; }

	public ICollection<Order> Orders { get; }
	
}
