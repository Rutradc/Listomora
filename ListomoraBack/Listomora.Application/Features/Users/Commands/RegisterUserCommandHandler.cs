using Isopoh.Cryptography.Argon2;
using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.Users.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Unit>
    {
        private readonly IUserRepo _repo;

        public RegisterUserCommandHandler(IUserRepo repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            string password = Argon2.Hash(request.Dto.Password);
            var userDto = request.Dto;
            userDto.Password = password;
            await _repo.RegisterAsync(userDto);
            return Unit.Value;
        }
    }
}
