using Listomora.Application.Contracts.Persistence.Dtos;
using MediatR;

namespace Listomora.Application.Features.Users.Commands
{
    public class RegisterUserCommand : IRequest<Unit>
    {
        public UserCreateDto Dto { get; set; }

        public RegisterUserCommand(UserCreateDto dto)
        {
            Dto = dto;
        }
    }
}
