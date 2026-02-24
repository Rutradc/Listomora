using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.Articles.Queries
{
    public class GetAllArticlesQueryHandler : IRequestHandler<GetAllArticlesQuery, IEnumerable<ArticleDetailsDto>>
    {
        private readonly IArticleRepo _repo;

        public GetAllArticlesQueryHandler(IArticleRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ArticleDetailsDto>> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAllAsync();
        }
    }
}
