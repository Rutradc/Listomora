using Listomora.Application.Contracts.Persistence.CustomExceptions;
using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.Ingredients.Commands
{
    public class UpdateIngredientCommandHandler : IRequestHandler<UpdateIngredientCommand, Unit>
    {
        private readonly IIngredientRepo _repo;

        public UpdateIngredientCommandHandler(IIngredientRepo repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(UpdateIngredientCommand request, CancellationToken cancellationToken)
        {
            if (request.IsAdmin)
            {
                if (await _repo.UpdateAsync(request.Id, request.Dto))
                    return Unit.Value;
            }
            if (await _repo.UpdateAsync(request.Id, request.Dto, request.UserId))
                return Unit.Value;
            throw new NotFoundException("Ingredient to update was not found.");
        }
    }
}
