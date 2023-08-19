using Microsoft.EntityFrameworkCore;
using Restaurant.Infrastucture.Entities;

namespace Restaurant.Infrastucture;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public virtual DbSet<Chef> Chefs { get; set; }
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<Owner> Owners { get; set; }
    public virtual DbSet<Table> Tables { get; set; }
    public virtual DbSet<Waiter> Waiters { get; set; }
    public virtual DbSet<Dish> Dishes { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        Configuration.ModelBuilder.BuildChef(modelBuilder.Entity<Chef>());
        Configuration.ModelBuilder.BuildCustomer(modelBuilder.Entity<Customer>());
        Configuration.ModelBuilder.BuildWaiter(modelBuilder.Entity<Waiter>());
        Configuration.ModelBuilder.BuildTable(modelBuilder.Entity<Table>());
        Configuration.ModelBuilder.BuildDish(modelBuilder.Entity<Dish>());
	}
}
