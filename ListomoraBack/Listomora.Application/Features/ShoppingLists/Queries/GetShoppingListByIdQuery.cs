using Listomora.Application.Contracts.Persistence.Dtos;
using MediatR;

namespace Listomora.Application.Features.ShoppingLists.Queries
{
    public class GetShoppingListByIdQuery : IRequest<ShoppingListDetailsDto>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public bool IsAdmin { get; set; }
        public GetShoppingListByIdQuery(Guid id, Guid userId)
        {
            Id = id;
            UserId = userId;
            IsAdmin = false;
        }

        public GetShoppingListByIdQuery(Guid id)
        {
            Id = id;
            IsAdmin = true;
        }
    }
}
