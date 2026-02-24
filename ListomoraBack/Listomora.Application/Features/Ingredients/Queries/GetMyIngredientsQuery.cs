using Listomora.Application.Contracts.Persistence.Dtos;
using MediatR;

namespace Listomora.Application.Features.Ingredients.Queries
{
    public class GetMyIngredientsQuery : IRequest<IEnumerable<IngredientDetailsDto>>
    {
        public Guid UserId { get; set; }

        public GetMyIngredientsQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
