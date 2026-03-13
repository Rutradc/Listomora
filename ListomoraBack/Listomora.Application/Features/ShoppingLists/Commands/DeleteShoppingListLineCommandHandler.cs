using Listomora.Application.Contracts.Persistence.CustomExceptions;
using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.ShoppingLists.Commands
{
    public class DeleteShoppingListLineCommandHandler : IRequestHandler<DeleteShoppingListLineCommand, Unit>
    {
        private readonly IShoppingListRepo _repo;

        public DeleteShoppingListLineCommandHandler(IShoppingListRepo repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(DeleteShoppingListLineCommand request, CancellationToken cancellationToken)
        {
            if (await _repo.DeleteLineAsync(request.ArticleId, request.ShoppingListId))
                return Unit.Value;
            throw new NotFoundException("Shoppinglist line was not found.");
        }
    }
}
