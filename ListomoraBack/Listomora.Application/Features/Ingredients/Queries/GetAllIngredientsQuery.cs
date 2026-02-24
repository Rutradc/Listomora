using Listomora.Application.Contracts.Persistence.Dtos;
using MediatR;

namespace Listomora.Application.Features.Ingredients.Queries
{
    public class GetAllIngredientsQuery : IRequest<IEnumerable<IngredientDetailsDto>>
    {
    }
}
