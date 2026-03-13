using Listomora.Application.Contracts.Persistence.Dtos;
using MediatR;

namespace Listomora.Application.Features.ShoppingLists.Commands
{
    public class UpdateShoppingListLineCommand : IRequest<Unit>
    {
        public Guid ArticleId { get; set; }
        public Guid ShoppingListId { get; set; }
        public ShoppingListLineUpdateDto Dto { get; set; }

        public UpdateShoppingListLineCommand(Guid articleId, Guid shoppingListId, ShoppingListLineUpdateDto dto)
        {
            ArticleId = articleId;
            ShoppingListId = shoppingListId;
            Dto = dto;
        }
    }
}
