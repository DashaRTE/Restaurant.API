using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        Configuration.ModelBuilder.BuildChef(builder.Entity<Chef>());
        Configuration.ModelBuilder.BuildCustomer(builder.Entity<Customer>());
        Configuration.ModelBuilder.BuildWaiter(builder.Entity<Waiter>());
        Configuration.ModelBuilder.BuildTable(builder.Entity<Table>());
    }
}
