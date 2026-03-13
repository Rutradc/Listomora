using Listomora.Application.Contracts.Persistence.Dtos;
using MediatR;

namespace Listomora.Application.Features.ShoppingLists.Queries
{
    public class GetAllShoppingListsQuery : IRequest<IEnumerable<ShoppingListListDto>>
    {
    }
}
