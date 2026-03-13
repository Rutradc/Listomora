using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.ShoppingLists.Commands
{
    public class CreateShoppingListCommandHandler : IRequestHandler<CreateShoppingListCommand, Unit>
    {
        private readonly IShoppingListRepo _repo;

        public CreateShoppingListCommandHandler(IShoppingListRepo repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(CreateShoppingListCommand request, CancellationToken cancellationToken)
        {
            await _repo.InsertAsync(request.Dto, request.CreatorId);
            return Unit.Value;
        }
    }
}
