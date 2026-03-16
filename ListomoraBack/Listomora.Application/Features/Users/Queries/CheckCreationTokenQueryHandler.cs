using Isopoh.Cryptography.Argon2;
using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.Users.Queries
{
    public class CheckCreationTokenQueryHandler : IRequestHandler<CheckCreationTokenQuery, bool>
    {
        private readonly IUserRepo _repo;

        public CheckCreationTokenQueryHandler(IUserRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(CheckCreationTokenQuery request, CancellationToken cancellationToken)
        {
            return await _repo.CheckCreationTokenAsync(Argon2.Hash(request.CreationToken));
        }
    }
}
