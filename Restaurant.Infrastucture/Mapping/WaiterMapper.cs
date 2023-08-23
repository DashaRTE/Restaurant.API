using AutoMapper;
using Restaurant.Core.Dto;
using Restaurant.Infrastucture.Entities;

namespace Restaurant.Infrastucture.Mapping;
public class WaiterMapper : Profile
{
	public WaiterMapper()
	{
		CreateMap<Waiter, WaiterDto>();
	}
}
