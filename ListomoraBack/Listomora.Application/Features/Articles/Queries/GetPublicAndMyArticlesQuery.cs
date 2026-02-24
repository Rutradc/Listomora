using Listomora.Application.Contracts.Persistence.Dtos;
using MediatR;

namespace Listomora.Application.Features.Articles.Queries
{
    public class GetPublicAndMyArticlesQuery : IRequest<IEnumerable<ArticleListDto>>
    {
        public Guid UserId { get; set; }

        public GetPublicAndMyArticlesQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
