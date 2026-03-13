using MediatR;

namespace Listomora.Application.Features.ShoppingLists.Commands
{
    public class DeleteShoppingListCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public bool IsAdmin { get; set; }
        public DeleteShoppingListCommand(Guid id, Guid userId)
        {
            Id = id;
            UserId = userId;
            IsAdmin = false;
        }

        public DeleteShoppingListCommand(Guid id)
        {
            Id = id;
            IsAdmin = true;
        }
    }
}
