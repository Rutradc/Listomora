using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.ShoppingLists.Commands
{
    public class CreateShoppingListCommandHandler : IRequestHandler<CreateShoppingListCommand, Guid>
    {
        private readonly IShoppingListRepo _repo;

        public CreateShoppingListCommandHandler(IShoppingListRepo repo)
        {
            _repo = repo;
        }

        public async Task<Guid> Handle(CreateShoppingListCommand request, CancellationToken cancellationToken)
        {
            return await _repo.InsertAsync(request.Dto, request.CreatorId);
        }
    }
}
