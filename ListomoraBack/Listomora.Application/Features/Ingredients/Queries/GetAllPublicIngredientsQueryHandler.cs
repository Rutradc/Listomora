using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.Ingredients.Queries
{
    public class GetAllPublicIngredientsQueryHandler : IRequestHandler<GetAllPublicIngredientsQuery, IEnumerable<IngredientListDto>>
    {
        private readonly IIngredientRepo _repo;

        public GetAllPublicIngredientsQueryHandler(IIngredientRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<IngredientListDto>> Handle(GetAllPublicIngredientsQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAllPublicAsync();
        }
    }
}
