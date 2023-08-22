using Restaurant.Infrastucture.Repositories.Interfaces;
using System.Net;

namespace Restaurant.Core.UseCases.Chef.Create;
public class CreateChefUseCase
{
	private readonly IChefRepository _chefRepository;

	public CreateChefUseCase(IChefRepository chefRepository)
	{
		_chefRepository = chefRepository;
	}

	public async Task<Result> HandleAsync(CreateChefRequest request)
	{
		await _chefRepository.CreateChefAsync(request.Email, request.Name, request.Password);

		return new Result() { StatusCode = HttpStatusCode.Created, Message = "Create chef" };
	}
}
