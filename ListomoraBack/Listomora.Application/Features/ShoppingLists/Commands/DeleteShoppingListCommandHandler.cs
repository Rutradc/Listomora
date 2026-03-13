using Listomora.Application.Contracts.Persistence.CustomExceptions;
using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.ShoppingLists.Commands
{
    public class DeleteShoppingListCommandHandler : IRequestHandler<DeleteShoppingListCommand, Unit>
    {
        private readonly IShoppingListRepo _repo;

        public DeleteShoppingListCommandHandler(IShoppingListRepo repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(DeleteShoppingListCommand request, CancellationToken cancellationToken)
        {
            bool isDeleted;
            if (request.IsAdmin)
                isDeleted = await _repo.DeleteAsync(request.Id);
            else
                isDeleted = await _repo.DeleteAsync(request.Id, request.UserId);
            if (isDeleted)
                return Unit.Value;
            throw new NotFoundException("Shoppinglist was not found.");
        }
    }
}
