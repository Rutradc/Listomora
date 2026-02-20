using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Domain.Repositories;
using MediatR;

namespace Listomora.Application.Features.Articles.Queries
{
    public class GetPublicArticlesQueryHandler : IRequestHandler<GetPublicArticlesQuery, IEnumerable<ArticleListDto>>
    {
        private readonly IArticleRepo _repo;

        public GetPublicArticlesQueryHandler(IArticleRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ArticleListDto>> Handle(GetPublicArticlesQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAllPublicAsync();
        }
    }
}
