using Listomora.API.Handlers;
using Listomora.Application.Contracts.Persistence.CustomExceptions;
using Listomora.Application.Contracts.Persistence.Repositories;
using Listomora.Domain.Models;
using MediatR;

namespace Listomora.Application.Features.Users.Queries
{
    public class CheckCreationTokenQueryHandler : IRequestHandler<CheckCreationTokenQuery, bool>
    {
        private readonly IUserRepo _repo;
        private readonly CreationTokenService _tokenService;

        public CheckCreationTokenQueryHandler(IUserRepo repo, CreationTokenService tokenService)
        {
            _repo = repo;
            _tokenService = tokenService;
        }

        public async Task<bool> Handle(CheckCreationTokenQuery request, CancellationToken cancellationToken)
        {
            var token = await _repo.GetCreationTokenAsync(_tokenService.HashToken(request.CreationToken));
            if (token == null)
                throw new InvalidTokenException();
            if (token.ExpiresAt < DateTime.UtcNow)
                throw new InvalidTokenException("Token has expired at " + token.ExpiresAt + " .");
            if (token.UsedAt is not null)
                throw new InvalidTokenException("Token has already been used at " + token.UsedAt + " .");
            return true;
        }
    }
}
