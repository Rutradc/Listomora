using Listomora.Application.Contracts.Persistence.CustomExceptions;
using Listomora.Domain.Repositories;
using MediatR;

namespace Listomora.Application.Features.Articles.Commands
{
    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, Unit>
    {
        private readonly IArticleRepo _repo;

        public UpdateArticleCommandHandler(IArticleRepo repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            if (request.IsAdmin)
            {
                if (await _repo.UpdateAsync(request.Id, request.Dto))
                    return Unit.Value;
            }
            if (await _repo.UpdateAsync(request.Id, request.Dto, request.UserId))
                return Unit.Value;
            throw new NotFoundException("Article to update was not found.");
        }
    }
}
