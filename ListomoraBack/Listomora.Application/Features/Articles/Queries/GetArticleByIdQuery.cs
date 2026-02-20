using Listomora.Application.Contracts.Persistence.Dtos;
using MediatR;

namespace Listomora.Application.Features.Articles.Queries
{
    public class GetArticleByIdQuery : IRequest<ArticleDetailsDto>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public bool IsAdmin { get; set; }

        public GetArticleByIdQuery(Guid id, Guid userId)
        {
            Id = id;
            UserId = userId;
            IsAdmin = false;
        }

        public GetArticleByIdQuery(Guid id)
        {
            Id = id;
            IsAdmin = true;
        }
    }
}
