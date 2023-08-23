using AutoMapper;
using Restaurant.Core.Dto;
using Restaurant.Infrastucture.Entities;

namespace Restaurant.Infrastucture.Mapping;
public class ChefMapper : Profile
{
	public ChefMapper()
	{
		CreateMap<Chef, ChefDto>();
	}
}
