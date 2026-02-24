using Listomora.Application.Contracts.Persistence.CustomExceptions;
using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.Ingredients.Commands
{
    public class DeleteIngredientCommandHandler : IRequestHandler<DeleteIngredientCommand, Unit>
    {
        private readonly IIngredientRepo _repo;

        public DeleteIngredientCommandHandler(IIngredientRepo repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(DeleteIngredientCommand request, CancellationToken cancellationToken)
        {
            bool isDeleted;
            if (request.IsAdmin)
                isDeleted = await _repo.DeleteAsync(request.Id);
            else
                isDeleted = await _repo.DeleteAsync(request.Id, request.UserId);
            if (isDeleted)
                return Unit.Value;
            throw new NotFoundException("Ingredient was not found.");
        }
    }
}
