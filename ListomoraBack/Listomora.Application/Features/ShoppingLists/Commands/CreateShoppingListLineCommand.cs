using Listomora.Application.Contracts.Persistence.Dtos;
using MediatR;

namespace Listomora.Application.Features.ShoppingLists.Commands
{
    public class CreateShoppingListLineCommand : IRequest<Unit>
    {
        public ShoppingListLineCreateDto Dto { get; set; }

        public CreateShoppingListLineCommand(ShoppingListLineCreateDto dto)
        {
            Dto = dto;
        }
    }
}
