using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.Articles.Queries
{
    public class GetAllPublicArticlesQueryHandler : IRequestHandler<GetAllPublicArticlesQuery, IEnumerable<ArticleListDto>>
    {
        private readonly IArticleRepo _repo;

        public GetAllPublicArticlesQueryHandler(IArticleRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ArticleListDto>> Handle(GetAllPublicArticlesQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAllPublicAsync();
        }
    }
}
