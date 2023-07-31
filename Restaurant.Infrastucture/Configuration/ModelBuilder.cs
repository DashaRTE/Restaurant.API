using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Infrastucture.Entities;

namespace Restaurant.Infrastucture.Configuration;
public static class ModelBuilder
{
    public static void BuildChef(EntityTypeBuilder<Chef> builder)
    {
        builder.HasMany(chef => chef.Orders)
            .WithOne(order => order.Chef)
            .HasForeignKey(chef => chef.ChefId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder.Property(static user => user.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(static user => user.Email)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(static user => user.Password)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(static chef => chef.CreationDate).HasDefaultValueSql("getutcdate()");
    }
    public static void BuildCustomer(EntityTypeBuilder<Customer> builder)
    {
        builder.HasMany(customer => customer.Orders)
            .WithOne(order => order.Customer)
            .HasForeignKey(customer => customer.CustomerId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder.Property(static user => user.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(static user => user.Email)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(static user => user.Password)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(static customer => customer.CreationDate).HasDefaultValueSql("getutcdate()");
    }
    public static void BuildWaiter(EntityTypeBuilder<Waiter> builder)
    {
        builder.HasMany(waiter => waiter.Orders)
            .WithOne(order => order.Waiter)
            .HasForeignKey(waiter => waiter.WaiterId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder.Property(static user => user.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(static user => user.Email)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(static user => user.Password)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(static waiter => waiter.CreationDate).HasDefaultValueSql("getutcdate()");
    }
    public static void BuildTable(EntityTypeBuilder<Table> builder)
    {
        builder.HasMany(table => table.Orders)
            .WithOne(order => order.Table)
            .HasForeignKey(table => table.TableId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder.Property(static table => table.CreationDate).HasDefaultValueSql("getutcdate()");
    }
}
