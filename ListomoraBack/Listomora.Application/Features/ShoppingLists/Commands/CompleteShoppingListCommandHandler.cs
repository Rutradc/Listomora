using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.ShoppingLists.Commands
{
    public class CompleteShoppingListCommandHandler : IRequestHandler<CompleteShoppingListCommand, Unit>
    {
        private readonly IShoppingListRepo _repo;

        public CompleteShoppingListCommandHandler(IShoppingListRepo repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(CompleteShoppingListCommand request, CancellationToken cancellationToken)
        {
            if (request.IsAdmin)
                await _repo.CompleteShoppingList(request.Id);
            else
                await _repo.CompleteShoppingList(request.Id, request.UserId);
            return Unit.Value;
        }
    }
}
