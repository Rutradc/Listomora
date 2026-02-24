using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.Ingredients.Queries
{
    public class GetAllIngredientsQueryHandler : IRequestHandler<GetAllIngredientsQuery, IEnumerable<IngredientDetailsDto>>
    {
        private readonly IIngredientRepo _repo;

        public GetAllIngredientsQueryHandler(IIngredientRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<IngredientDetailsDto>> Handle(GetAllIngredientsQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAllAsync();
        }
    }
}
