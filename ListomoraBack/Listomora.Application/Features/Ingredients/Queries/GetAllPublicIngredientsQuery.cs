using Listomora.Application.Contracts.Persistence.Dtos;
using MediatR;

namespace Listomora.Application.Features.Ingredients.Queries
{
    public class GetAllPublicIngredientsQuery : IRequest<IEnumerable<IngredientListDto>>
    {
    }
}
