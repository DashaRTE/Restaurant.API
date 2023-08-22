using Restaurant.Infrastucture.Repositories.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Owner.Get;
public class GetOwnerUseCase
{
	private readonly IOwnerRepository _ownerRepository;

	public GetOwnerUseCase(IOwnerRepository ownerRepository)
	{
		_ownerRepository = ownerRepository;
	}

	public async Task<Result<List<Infrastucture.Entities.Owner>>> HandleAsync()
	{
		var result = await _ownerRepository.GetOwnersAsync();

		return new() { StatusCode = HttpStatusCode.OK, Message = "Get owners", Data = result };
	}
}
