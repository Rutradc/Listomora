using Listomora.Application.Contracts.Persistence.Dtos;
using MediatR;

namespace Listomora.Application.Features.ShoppingLists.Commands
{
    public class CreateShoppingListCommand : IRequest<Unit>
    {
        public ShoppingListCreateDto Dto { get; set; }
        public Guid CreatorId { get; set; }

        public CreateShoppingListCommand(ShoppingListCreateDto dto, Guid creatorId)
        {
            Dto = dto;
            CreatorId = creatorId;
        }
    }
}
