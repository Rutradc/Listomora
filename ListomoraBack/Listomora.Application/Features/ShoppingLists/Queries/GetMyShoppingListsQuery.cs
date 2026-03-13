using Listomora.Application.Contracts.Persistence.Dtos;
using MediatR;

namespace Listomora.Application.Features.ShoppingLists.Queries
{
    public class GetMyShoppingListsQuery : IRequest<IEnumerable<ShoppingListListDto>>
    {
        public Guid UserId { get; set; }

        public GetMyShoppingListsQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
