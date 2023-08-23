using AutoMapper;
using Restaurant.Core.Dto;
using Restaurant.Infrastucture.Entities;

namespace Restaurant.Infrastucture.Mapping;
public class OrderMapper : Profile
{
	public OrderMapper()
	{
		CreateMap<Order, OrderDto>();
	}
}
