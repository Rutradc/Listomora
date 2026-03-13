using Listomora.Application.Contracts.Persistence.Dtos;
using MediatR;

namespace Listomora.Application.Features.ShoppingLists.Commands
{
    public class UpdateShoppingListCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public ShoppingListUpdateDto Dto { get; set; }
        public Guid UserId { get; set; }
        public bool IsAdmin { get; set; }
        public UpdateShoppingListCommand(Guid id, ShoppingListUpdateDto dto, Guid userId)
        {
            Id = id;
            Dto = dto;
            UserId = userId;
            IsAdmin = false;
        }
        public UpdateShoppingListCommand(Guid id, ShoppingListUpdateDto dto)
        {
            Id = id;
            Dto = dto;
            IsAdmin = true;
        }
    }
}
