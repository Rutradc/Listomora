using Listomora.Application.Contracts.Persistence.CustomExceptions;
using Listomora.Domain.Repositories;
using MediatR;

namespace Listomora.Application.Features.Articles.Commands
{
    public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand, Unit>
    {
        private readonly IArticleRepo _repo;

        public DeleteArticleCommandHandler(IArticleRepo repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            bool isDeleted;
            if (request.IsAdmin)
                isDeleted = await _repo.DeleteAsync(request.Id);
            else
                isDeleted = await _repo.DeleteAsync(request.Id, request.UserId);
            if (isDeleted)
                return Unit.Value;
            throw new NotFoundException("Article was not found.");
        }
    }
}
