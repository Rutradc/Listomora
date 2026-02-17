using Listomora.Domain.Model;
using Listomora.Domain.Repositories;
using MediatR;

namespace Listomora.Application.Features.Articles.Queries
{
    public class GetArticlesQueryHandler : IRequestHandler<GetArticlesQuery, IEnumerable<Article>>
    {
        private readonly IArticleRepo _repo;

        public GetArticlesQueryHandler(IArticleRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Article>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAllAsync();
        }
    }
}
