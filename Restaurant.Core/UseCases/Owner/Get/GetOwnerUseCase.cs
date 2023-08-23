using Restaurant.Core.Dto;
using Restaurant.Core.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Owner.Get;
public class GetOwnerUseCase
{
	private readonly IOwnerRepository _ownerRepository;

	public GetOwnerUseCase(IOwnerRepository ownerRepository)
	{
		_ownerRepository = ownerRepository;
	}

	public async Task<Result<IList<OwnerDto>>> HandleAsync()
	{
		var owners = await _ownerRepository.GetOwnersAsync();

		return new() { StatusCode = HttpStatusCode.OK, Message = "Get owners", Data = owners };
	}
}
