using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.Ingredients.Queries
{
    public class GetIngredientByIdQueryHandler : IRequestHandler<GetIngredientByIdQuery, IngredientDetailsDto>
    {
        private readonly IIngredientRepo _repo;

        public GetIngredientByIdQueryHandler(IIngredientRepo repo)
        {
            _repo = repo;
        }

        public async Task<IngredientDetailsDto> Handle(GetIngredientByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.IsAdmin)
                return await _repo.GetByIdAsync(request.Id);
            return await _repo.GetByIdAsync(request.Id, request.UserId);
        }
    }
}
