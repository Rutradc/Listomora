using Listomora.Domain.Model;
using Listomora.Domain.Repositories;
using MediatR;

namespace Listomora.Application.Features.Articles.Commands
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, Unit>
    {
        private readonly IArticleRepo _repo;

        public CreateArticleCommandHandler(IArticleRepo repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var article = new Article()
            {
                Name = request.Name,
                IsPublic = request.IsPublic
            };
            await _repo.InsertAsync(article);
            return Unit.Value;
        }
    }
}
