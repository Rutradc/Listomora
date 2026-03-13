using Listomora.Application.Contracts.Persistence.CustomExceptions;
using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.ShoppingLists.Commands
{
    public class UpdateShoppingListLineCommandHandler : IRequestHandler<UpdateShoppingListLineCommand, Unit>
    {
        private readonly IShoppingListRepo _repo;

        public UpdateShoppingListLineCommandHandler(IShoppingListRepo repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(UpdateShoppingListLineCommand request, CancellationToken cancellationToken)
        {
            if (await _repo.UpdateLineAsync(request.ArticleId, request.ShoppingListId , request.Dto))
                return Unit.Value;
            throw new NotFoundException("Shoppinglist line to update was not found.");
        }
    }
}
