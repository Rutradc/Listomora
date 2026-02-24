using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.Articles.Queries
{
    public class GetMyArticlesQueryHandler : IRequestHandler<GetMyArticlesQuery, IEnumerable<ArticleDetailsDto>>
    {
        private readonly IArticleRepo _repo;

        public GetMyArticlesQueryHandler(IArticleRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ArticleDetailsDto>> Handle(GetMyArticlesQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetMineAsync(request.UserId);
        }
    }
}
