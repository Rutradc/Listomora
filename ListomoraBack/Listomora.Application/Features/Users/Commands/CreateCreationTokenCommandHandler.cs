using Listomora.API.Handlers;
using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.Users.Commands
{
    public class CreateCreationTokenCommandHandler : IRequestHandler<CreateCreationTokenCommand, Unit>
    {
        private readonly IUserRepo _repo;
        private readonly CreationTokenService _tokenService;

        public CreateCreationTokenCommandHandler(IUserRepo repo, CreationTokenService tokenService)
        {
            _repo = repo;
            _tokenService = tokenService;
        }

        public async Task<Unit> Handle(CreateCreationTokenCommand request, CancellationToken cancellationToken)
        {
            request.Dto.TokenHash = _tokenService.HashToken(request.Dto.TokenHash);
            await _repo.CreateCreationTokenAsync(request.Dto);
            return Unit.Value;
        }
    }
}
