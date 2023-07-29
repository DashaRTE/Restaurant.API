using Microsoft.AspNetCore.Identity;

namespace Restaurant.Infrastucture.Entities;
public class User : IdentityUser
{
    public User()
    {
        CreationDate = DateTime.UtcNow;
    }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}
