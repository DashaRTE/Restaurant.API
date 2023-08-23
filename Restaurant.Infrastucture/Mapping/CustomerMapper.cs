using Restaurant.Infrastucture.Entities;
using AutoMapper;
using Restaurant.Core.Dto;

namespace Restaurant.Infrastucture.Mapping;
public class CustomerMapper : Profile
{
	public CustomerMapper()
	{
		CreateMap<Customer, CustomerDto>();
	}
}
