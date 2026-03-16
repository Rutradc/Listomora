using Isopoh.Cryptography.Argon2;
using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.Users.Commands
{
    public class CreateCreationTokenCommandHandler : IRequestHandler<CreateCreationTokenCommand, Unit>
    {
        private readonly IUserRepo _repo;

        public CreateCreationTokenCommandHandler(IUserRepo repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(CreateCreationTokenCommand request, CancellationToken cancellationToken)
        {
            request.Dto.TokenHash = Argon2.Hash(request.Dto.TokenHash);
            await _repo.CreateCreationTokenAsync(request.Dto);
            return Unit.Value;
        }
    }
}
