namespace Restaurant.Infrastucture.Entities;
public class User : Entity
{
    public User()
    {
        CreationDate = DateTime.UtcNow;
    }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
