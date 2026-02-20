using Listomora.Application.Contracts.Persistence.Dtos;
using MediatR;

namespace Listomora.Application.Features.Articles.Commands
{
    public class UpdateArticleCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public ArticleCreateUpdateDto Dto { get; set; }
        public Guid UserId { get; set; }
        public bool IsAdmin { get; set; }

        public UpdateArticleCommand(Guid id, ArticleCreateUpdateDto dto, Guid userId)
        {
            Id = id;
            Dto = dto;
            UserId = userId;
            IsAdmin = false;
        }
        public UpdateArticleCommand(Guid id, ArticleCreateUpdateDto dto)
        {
            Id = id;
            Dto = dto;
            IsAdmin = true;
        }
    }
}
