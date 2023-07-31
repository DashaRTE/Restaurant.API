﻿using Microsoft.EntityFrameworkCore;
using Restaurant.Infrastucture.Entities;
using Restaurant.Infrastucture.Repositories.Interfaces;

namespace Restaurant.Infrastucture.Repositories;
public class CustomerRepository : ICustomerRepository
{
    private readonly DataContext _dataContext;
    public CustomerRepository(DataContext context)
    {
        _dataContext = context;
    }
    public async Task<List <Customer>> GetCustomersAsync()
    {
        return await _dataContext.Customers.ToListAsync();
    }
    public async Task<Customer> CreateCustomerAsync(string Email, string Name, string Password)
    {
        var customer = new Customer() {Email = Email, Name = Name, Password = Password};
        await _dataContext.Customers.AddAsync(customer);
        await _dataContext.SaveChangesAsync();
        return customer;
    }
    public async Task<Customer?> EditCustomerAsync(Guid CustomerId, string Email, string Name, string Password)
    {
        var customer = await _dataContext.Customers.FindAsync(CustomerId);
        if (customer is not null) 
        {
            customer.Email = Email;
            customer.Name = Name;
            customer.Password = Password;
            await _dataContext.SaveChangesAsync();
        }
        return customer;
    }
    public async Task DeleteCustomerAsync(Guid CustomerId)
    {
        var customer = await _dataContext.Customers.FindAsync(CustomerId);
        if (customer is not null)
        {
            _dataContext.Customers.Remove(customer);
            await _dataContext.SaveChangesAsync();
        }
    }
    public async Task<Customer?> GetCustomerByIdAsync(Guid CustomerId)
    {
        var customer = await _dataContext.Customers.FindAsync(CustomerId);
        if (customer is not null)
        {
            return customer;
        }
        return null;
    }
}