using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.ShoppingLists.Commands
{
    public class CreateShoppingListLineCommandHandler : IRequestHandler<CreateShoppingListLineCommand, Unit>
    {
        private readonly IShoppingListRepo _repo;

        public CreateShoppingListLineCommandHandler(IShoppingListRepo repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(CreateShoppingListLineCommand request, CancellationToken cancellationToken)
        {
            await _repo.InsertLineAsync(request.Dto);
            return Unit.Value;
        }
    }
}
