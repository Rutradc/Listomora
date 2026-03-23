using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.ShoppingLists.Commands
{
    public class UpdateShoppingListLinesCommandHandler : IRequestHandler<UpdateShoppingListLinesCommand, Unit>
    {
        private readonly IShoppingListRepo _repo;

        public UpdateShoppingListLinesCommandHandler(IShoppingListRepo repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(UpdateShoppingListLinesCommand request, CancellationToken cancellationToken)
        {
            await _repo.UpdateLinesAsync(request.Dtos);
            return Unit.Value;
        }
    }
}
