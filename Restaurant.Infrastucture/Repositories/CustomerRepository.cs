using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Dto;
using Restaurant.Core.Interfaces;
using Restaurant.Infrastucture.Entities;

namespace Restaurant.Infrastucture.Repositories;

public class CustomerRepository : ICustomerRepository
{
	private readonly DataContext _dataContext;
	private readonly IMapper _mapper;


	public CustomerRepository(DataContext context, IMapper mapper)
	{
		_dataContext = context;
		_mapper = mapper;
	}

	public async Task<IList<CustomerDto>> GetCustomersAsync() =>
		_mapper.Map<IList<Customer>, IList<CustomerDto>>(await _dataContext.Customers.ToListAsync());

	public async Task<CustomerDto?> GetCustomerByIdAsync(Guid customerId) =>
		_mapper.Map<Customer?, CustomerDto?>(await _dataContext.Customers.FindAsync(customerId));

	public async Task<CustomerDto?> GetCustomerOrdersAsync(Guid customerId)
	{
		var customer = await _dataContext.Customers.Include(customer => customer.Orders)
			.FirstOrDefaultAsync(customer => customer.Id == customerId);

		return _mapper.Map<Customer, CustomerDto>(customer);

	}

	public async Task<CustomerDto> CreateCustomerAsync(string email, string name, string password)
	{
		var customer = new Customer { Email = email, Name = name, Password = password };

		await _dataContext.Customers.AddAsync(customer);

		await _dataContext.SaveChangesAsync();

		return _mapper.Map<Customer, CustomerDto>(customer);
	}

	public async Task<CustomerDto?> EditCustomerAsync(Guid customerId, string email, string name, string password)
	{
		var customer = await _dataContext.Customers.FindAsync(customerId);

		if (customer is not null)
		{
			customer.Email = email;
			customer.Name = name;
			customer.Password = password;
			customer.ModifiedDate = DateTime.UtcNow;

			_dataContext.Entry(customer).State = EntityState.Modified;

			await _dataContext.SaveChangesAsync();
		}

		return _mapper.Map<Customer?, CustomerDto?>(customer);
	}

	public async Task DeleteCustomerAsync(Guid customerId)
	{
		var customer = await _dataContext.Customers.FindAsync(customerId);

		if (customer is not null)
		{
			_dataContext.Customers.Remove(customer);

			await _dataContext.SaveChangesAsync();
		}
	}
}