using Listomora.Application.Contracts.Persistence.Dtos;
using MediatR;

namespace Listomora.Application.Features.Articles.Queries
{
    public class GetMyArticlesQuery : IRequest<IEnumerable<ArticleDetailsDto>>
    {
        public Guid UserId { get; set; }

        public GetMyArticlesQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
