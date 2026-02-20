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
            await _repo.InsertAsync(request.Dto, request.CreatorId);
            return Unit.Value;
        }
    }
}
