using Restaurant.Core.Dto;
using Restaurant.Core.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Owner.GetById;
public class GetOwnerByIdUseCase
{
	private readonly IOwnerRepository _ownerRepository;

	public GetOwnerByIdUseCase(IOwnerRepository ownerRepository)
	{
		_ownerRepository = ownerRepository;
	}

	public async Task<Result<OwnerDto>> HandleAsync(Guid ownerId)
	{
		var owner = await _ownerRepository.GetOwnerByIdAsync(ownerId);

		if (owner is null)
		{
			return new() { StatusCode = HttpStatusCode.NotFound, Message = "Not found" };
		}

		return new() { StatusCode = HttpStatusCode.OK, Message = "Get owner by id", Data = owner };
	}
}
