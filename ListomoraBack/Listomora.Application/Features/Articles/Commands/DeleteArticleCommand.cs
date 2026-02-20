using MediatR;

namespace Listomora.Application.Features.Articles.Commands
{
    public class DeleteArticleCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public bool IsAdmin { get; set; }

        public DeleteArticleCommand(Guid id, Guid userId)
        {
            Id = id;
            UserId = userId;
            IsAdmin = false;
        }

        public DeleteArticleCommand(Guid id)
        {
            Id = id;
            IsAdmin = true;
        }
    }
}
