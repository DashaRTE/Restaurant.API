using Restaurant.Infrastucture.Repositories.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Owner.GetById;
public class GetOwnerByIdUseCase
{
	private readonly IOwnerRepository _ownerRepository;

	public GetOwnerByIdUseCase(IOwnerRepository ownerRepository)
	{
		_ownerRepository = ownerRepository;
	}

	public async Task<Result<Infrastucture.Entities.Owner>> HandleAsync(Guid ownerId)
	{
		var result = await _ownerRepository.GetOwnerByIdAsync(ownerId);

		if (result is null)
		{
			return new() { StatusCode = HttpStatusCode.NotFound, Message = "Not found" };
		}

		return new() { StatusCode = HttpStatusCode.OK, Message = "Get owner by id", Data = result };
	}
}
