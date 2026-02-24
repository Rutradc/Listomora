using MediatR;

namespace Listomora.Application.Features.Ingredients.Commands
{
    public class DeleteIngredientCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public bool IsAdmin { get; set; }

        public DeleteIngredientCommand(Guid id, Guid userId)
        {
            Id = id;
            UserId = userId;
            IsAdmin = false;
        }

        public DeleteIngredientCommand(Guid id)
        {
            Id = id;
            IsAdmin = true;
        }
    }
}
