using Listomora.Application.Contracts.Persistence.Dtos;
using MediatR;

namespace Listomora.Application.Features.Ingredients.Commands
{
    public class UpdateIngredientCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public IngredientCreateUpdateDto Dto { get; set; }
        public Guid UserId { get; set; }
        public bool IsAdmin { get; set; }

        public UpdateIngredientCommand(Guid id, IngredientCreateUpdateDto dto, Guid userId)
        {
            Id = id;
            Dto = dto;
            UserId = userId;
            IsAdmin = false;
        }
        public UpdateIngredientCommand(Guid id, IngredientCreateUpdateDto dto)
        {
            Id = id;
            Dto = dto;
            IsAdmin = true;
        }
    }
}
