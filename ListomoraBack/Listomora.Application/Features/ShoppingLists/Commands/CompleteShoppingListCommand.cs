using MediatR;

namespace Listomora.Application.Features.ShoppingLists.Commands
{
    public class CompleteShoppingListCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public bool IsAdmin { get; set; }

        public CompleteShoppingListCommand(Guid id, Guid? userId = null)
        {
            Id = id;
            UserId = userId;
            IsAdmin = userId != null;
        }
    }
}
