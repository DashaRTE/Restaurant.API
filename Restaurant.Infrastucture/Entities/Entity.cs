using System.ComponentModel.DataAnnotations;

namespace Restaurant.Infrastucture.Entities;
public abstract class Entity
{
    [Key]
    public Guid Id { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}