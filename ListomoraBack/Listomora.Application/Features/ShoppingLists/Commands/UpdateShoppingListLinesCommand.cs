using Listomora.Application.Contracts.Persistence.Dtos;
using MediatR;

namespace Listomora.Application.Features.ShoppingLists.Commands
{
    public class UpdateShoppingListLinesCommand : IRequest<Unit>
    {
        public ShoppingListLinesUpdateDto Dto { get; set; }

        public UpdateShoppingListLinesCommand(ShoppingListLinesUpdateDto dto)
        {
            Dto = dto;
        }
    }
}
