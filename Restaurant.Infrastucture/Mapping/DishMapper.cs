using AutoMapper;
using Restaurant.Core.Dto;
using Restaurant.Infrastucture.Entities;

namespace Restaurant.Infrastucture.Mapping;
public class DishMapper : Profile
{
	public DishMapper()
	{
		CreateMap<Dish, DishDto>();
	}
}
