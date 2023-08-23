using AutoMapper;
using Restaurant.Core.Dto;
using Restaurant.Infrastucture.Entities;

namespace Restaurant.Infrastucture.Mapping;
public class EntityMapper : Profile
{
	public EntityMapper()
	{
		CreateMap<Entity, EntityDto>();
	}
}
