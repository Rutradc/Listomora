using Listomora.Application.Contracts.Persistence.CustomExceptions;
using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.Users.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepo _repo;

        public UpdateUserCommandHandler(IUserRepo repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (await _repo.UpdateAsync(request.Id, request.Dto))
                return Unit.Value;
            throw new NotFoundException("User to update was not found.");
        }
    }
}
