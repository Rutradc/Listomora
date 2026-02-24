using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.Ingredients.Queries
{
    public class GetPublicAndMyIngredientsQueryHandler : IRequestHandler<GetPublicAndMyIngredientsQuery, IEnumerable<IngredientListDto>>
    {
        private readonly IIngredientRepo _repo;

        public GetPublicAndMyIngredientsQueryHandler(IIngredientRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<IngredientListDto>> Handle(GetPublicAndMyIngredientsQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetPublicAndMineAsync(request.UserId);
        }
    }
}
