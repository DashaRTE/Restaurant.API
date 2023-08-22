using Restaurant.Infrastucture.Repositories.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Owner.Delete;
public class DeleteOwnerUseCase
{
	private readonly IOwnerRepository _ownerRepository;

	public DeleteOwnerUseCase(IOwnerRepository ownerRepository)
	{
		_ownerRepository = ownerRepository;
	}

	public async Task<Result> HandleAsync(Guid ownerId)
	{
		var owner = await _ownerRepository.GetOwnerByIdAsync(ownerId);

		if (owner is null)
		{
			return new Result() { StatusCode = HttpStatusCode.NotFound, Message = "Not found" };
		}

		await _ownerRepository.DeleteOwnerAsync(ownerId);

		return new Result() { StatusCode = HttpStatusCode.OK, Message = "Delete owner" };
	}
}
