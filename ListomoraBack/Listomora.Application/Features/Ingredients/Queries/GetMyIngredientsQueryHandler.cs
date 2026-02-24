using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.Ingredients.Queries
{
    public class GetMyIngredientsQueryHandler : IRequestHandler<GetMyIngredientsQuery, IEnumerable<IngredientDetailsDto>>
    {
        private readonly IIngredientRepo _repo;

        public GetMyIngredientsQueryHandler(IIngredientRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<IngredientDetailsDto>> Handle(GetMyIngredientsQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetMineAsync(request.UserId);
        }
    }
}
