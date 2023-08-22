using Restaurant.Infrastucture.Repositories.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Owner.Edit;
public class EditOwnerUseCase
{
	private readonly IOwnerRepository _ownerRepository;

	public EditOwnerUseCase(IOwnerRepository ownerRepository)
	{
		_ownerRepository = ownerRepository;
	}

	public async Task<Result> HandleAsync(EditOwnerRequest request)
	{
		var owner = await _ownerRepository.GetOwnerByIdAsync(request.OwnerId);

		if (owner is null)
		{
			return new Result() { StatusCode = HttpStatusCode.NotFound, Message = "Not found" };
		}

		await _ownerRepository.EditOwnerAsync(request.OwnerId, request.Email, request.Name, request.Password);

		return new Result() { StatusCode = HttpStatusCode.OK, Message = "Edit owner" };
	}
}
