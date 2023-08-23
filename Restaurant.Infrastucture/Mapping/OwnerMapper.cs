using AutoMapper;
using Restaurant.Core.Dto;
using Restaurant.Infrastucture.Entities;

namespace Restaurant.Infrastucture.Mapping;
public class OwnerMapper : Profile
{
	public OwnerMapper()
	{
		CreateMap<Owner, OwnerDto>();
	}
}
