using Listomora.Application.Contracts.Persistence.CustomExceptions;
using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.ShoppingLists.Commands
{
    public class UpdateShoppingListCommandHandler : IRequestHandler<UpdateShoppingListCommand, Unit>
    {
        private readonly IShoppingListRepo _repo;

        public UpdateShoppingListCommandHandler(IShoppingListRepo repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(UpdateShoppingListCommand request, CancellationToken cancellationToken)
        {
            if (request.IsAdmin)
            {
                if (await _repo.UpdateAsync(request.Id, request.Dto))
                    return Unit.Value;
            }
            if (await _repo.UpdateAsync(request.Id, request.Dto, request.UserId))
                return Unit.Value;
            throw new NotFoundException("Shoppinglist to update was not found.");
        }
    }
}
