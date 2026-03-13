using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.ShoppingLists.Queries
{
    public class GetMyShoppingListsQueryHandler : IRequestHandler<GetMyShoppingListsQuery, IEnumerable<ShoppingListListDto>>
    {
        private readonly IShoppingListRepo _repo;

        public GetMyShoppingListsQueryHandler(IShoppingListRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ShoppingListListDto>> Handle(GetMyShoppingListsQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetMineAsync(request.UserId);
        }
    }
}
