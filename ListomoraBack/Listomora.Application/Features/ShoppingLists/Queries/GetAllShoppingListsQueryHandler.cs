using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.ShoppingLists.Queries
{
    public class GetAllShoppingListsQueryHandler : IRequestHandler<GetAllShoppingListsQuery, IEnumerable<ShoppingListListDto>>
    {
        private readonly IShoppingListRepo _repo;

        public GetAllShoppingListsQueryHandler(IShoppingListRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ShoppingListListDto>> Handle(GetAllShoppingListsQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAllAsync();
        }
    }
}
