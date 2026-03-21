using Listomora.Application.Contracts.Persistence.Dtos;
using MediatR;

namespace Listomora.Application.Features.ShoppingLists.Commands
{
    public class UpdateShoppingListLinesCommand : IRequest<Unit>
    {
        public IEnumerable<ShoppingListLineCreateUpdateDto> Dtos { get; set; }

        public UpdateShoppingListLinesCommand(IEnumerable<ShoppingListLineCreateUpdateDto> dtos)
        {
            Dtos = dtos;
        }
    }
}
