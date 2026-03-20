using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.Articles.Queries
{
    public class SearchArticleByStringQueryHandler : IRequestHandler<SearchArticleByStringQuery, IEnumerable<ShoppingListLineArticleDto>>
    {
        private readonly IArticleRepo _repo;

        public SearchArticleByStringQueryHandler(IArticleRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ShoppingListLineArticleDto>> Handle(SearchArticleByStringQuery request, CancellationToken cancellationToken)
        {
            if (request.IsAdmin)
                return await _repo.Search(request.SearchString);
            return await _repo.Search(request.SearchString, request.UserId);
        }
    }
}
