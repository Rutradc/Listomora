using Listomora.Application.Contracts.Persistence.Dtos;
using MediatR;

namespace Listomora.Application.Features.Ingredients.Queries
{
    public class GetPublicAndMyIngredientsQuery : IRequest<IEnumerable<IngredientListDto>>
    {
        public Guid UserId { get; set; }

        public GetPublicAndMyIngredientsQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
