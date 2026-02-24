using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.Ingredients.Commands
{
    public class CreateIngredientCommandHandler : IRequestHandler<CreateIngredientCommand, Unit>
    {
        private readonly IIngredientRepo _repo;

        public CreateIngredientCommandHandler(IIngredientRepo repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
        {
            await _repo.InsertAsync(request.Dto, request.CreatorId);
            return Unit.Value;
        }
    }
}
