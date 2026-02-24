using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.Articles.Queries
{
    public class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, ArticleDetailsDto>
    {
        private readonly IArticleRepo _repo;

        public GetArticleByIdQueryHandler(IArticleRepo repo)
        {
            _repo = repo;
        }

        public async Task<ArticleDetailsDto> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.IsAdmin)
                return await _repo.GetByIdAsync(request.Id);
            return await _repo.GetByIdAsync(request.Id, request.UserId);
        }
    }
}
