using AutoMapper;
using Restaurant.Core.Dto;
using Restaurant.Infrastucture.Entities;

namespace Restaurant.Infrastucture.Mapping;
public class UserMapper : Profile
{
	public UserMapper()
	{
		CreateMap<User, UserDto>();
	}
}
