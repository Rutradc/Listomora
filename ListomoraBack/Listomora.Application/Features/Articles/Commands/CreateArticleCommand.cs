using MediatR;

namespace Listomora.Application.Features.Articles.Commands
{
    public class CreateArticleCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        //public Guid CreatorId { get; set; }

        public CreateArticleCommand(string name, bool isPublic)
        {
            Name = name;
            IsPublic = isPublic;
        }
    }
}
