using Restaurant.Core.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Owner.Create;
public class CreateOwnerUseCase
{
	private readonly IOwnerRepository _ownerRepository;

	public CreateOwnerUseCase(IOwnerRepository ownerRepository)
	{
		_ownerRepository = ownerRepository;
	}

	public async Task<Result> HandleAsync(CreateOwnerRequest request)
	{
		await _ownerRepository.CreateOwnerAsync(request.Email, request.Name, request.Password);

		return new Result() { StatusCode = HttpStatusCode.Created, Message = "Create owner" };
	}
}
