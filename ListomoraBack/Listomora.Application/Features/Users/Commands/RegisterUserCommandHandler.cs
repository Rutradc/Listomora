using Isopoh.Cryptography.Argon2;
using Listomora.API.Handlers;
using Listomora.Application.Contracts.Persistence.CustomExceptions;
using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.Users.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Unit>
    {
        private readonly IUserRepo _repo;
        private readonly CreationTokenService _tokenService;

        public RegisterUserCommandHandler(IUserRepo repo, CreationTokenService tokenService)
        {
            _repo = repo;
            _tokenService = tokenService;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userDto = request.Dto;
            userDto.Password = Argon2.Hash(userDto.Password);
            userDto.CreationToken = _tokenService.HashToken(userDto.CreationToken);
            if (!await _repo.RegisterAsync(userDto))
                throw new InvalidTokenException();
            return Unit.Value;
        }
    }
}
