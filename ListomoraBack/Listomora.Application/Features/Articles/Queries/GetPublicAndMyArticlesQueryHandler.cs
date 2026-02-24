using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.Articles.Queries
{
    public class GetPublicAndMyArticlesQueryHandler : IRequestHandler<GetPublicAndMyArticlesQuery, IEnumerable<ArticleListDto>>
    {
        private readonly IArticleRepo _repo;

        public GetPublicAndMyArticlesQueryHandler(IArticleRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ArticleListDto>> Handle(GetPublicAndMyArticlesQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetPublicAndMineAsync(request.UserId);
        }
    }
}
