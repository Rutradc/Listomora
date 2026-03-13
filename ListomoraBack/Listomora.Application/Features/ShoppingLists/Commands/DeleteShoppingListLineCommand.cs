using MediatR;

namespace Listomora.Application.Features.ShoppingLists.Commands
{
    public class DeleteShoppingListLineCommand : IRequest<Unit>
    {
        public Guid ArticleId { get; set; }
        public Guid ShoppingListId { get; set; }

        public DeleteShoppingListLineCommand(Guid articleId, Guid shoppingListId)
        {
            ArticleId = articleId;
            ShoppingListId = shoppingListId;
        }
    }
}
