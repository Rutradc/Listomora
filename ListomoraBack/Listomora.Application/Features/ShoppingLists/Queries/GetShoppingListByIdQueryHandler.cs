using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.ShoppingLists.Queries
{
    public class GetShoppingListByIdQueryHandler : IRequestHandler<GetShoppingListByIdQuery, ShoppingListDetailsDto>
    {
        private readonly IShoppingListRepo _repo;

        public GetShoppingListByIdQueryHandler(IShoppingListRepo repo)
        {
            _repo = repo;
        }

        public async Task<ShoppingListDetailsDto> Handle(GetShoppingListByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.IsAdmin)
                return await _repo.GetByIdAsync(request.Id);
            return await _repo.GetByIdAsync(request.Id, request.UserId);
        }
    }
}
