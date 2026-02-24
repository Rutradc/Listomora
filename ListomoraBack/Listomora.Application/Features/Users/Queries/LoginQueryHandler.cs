using Isopoh.Cryptography.Argon2;
using Listomora.Application.Contracts.Persistence.CustomExceptions;
using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Domain.Enums;
using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.Users.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, UserForToken>
    {
        private readonly IUserRepo _repo;

        public LoginQueryHandler(IUserRepo repo)
        {
            _repo = repo;
        }

        public async Task<UserForToken> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _repo.GetByEmailAsync(request.Credentials.Email);
            if (user is null || !Argon2.Verify(user.Password, request.Credentials.Password))
                throw new InvalidCredentialsException();
            return new UserForToken(user.Id, (UserRole)user.Role);
        }
    }
}
