using AutoMapper;
using Restaurant.Core.Dto;
using Restaurant.Infrastucture.Entities;

namespace Restaurant.Infrastucture.Mapping;
public class TableMapper : Profile
{
	public TableMapper()
	{
		CreateMap<Table, TableDto>();
	}
}
