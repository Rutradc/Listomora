using Listomora.Application.Contracts.Persistence.Dtos;
using MediatR;

namespace Listomora.Application.Features.Ingredients.Commands
{
    public class CreateIngredientCommand : IRequest<Unit>
    {
        public IngredientCreateUpdateDto Dto { get; set; }
        public Guid CreatorId { get; set; }

        public CreateIngredientCommand(IngredientCreateUpdateDto dto, Guid creatorId)
        {
            Dto = dto;
            CreatorId = creatorId;
        }
    }
}
