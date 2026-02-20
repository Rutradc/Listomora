using Listomora.Application.Contracts.Persistence.Dtos;
using MediatR;

namespace Listomora.Application.Features.Articles.Commands
{
    public class CreateArticleCommand : IRequest<Unit>
    {
        public ArticleCreateUpdateDto Dto { get; set; }
        public Guid CreatorId { get; set; }

        public CreateArticleCommand(ArticleCreateUpdateDto dto, Guid creatorId)
        {
            Dto = dto;
            CreatorId = creatorId;
        }
    }
}
