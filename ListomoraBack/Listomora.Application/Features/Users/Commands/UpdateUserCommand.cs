using Listomora.Application.Contracts.Persistence.Dtos;
using MediatR;

namespace Listomora.Application.Features.Users.Commands
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public UserUpdateDto Dto { get; set; }

        public UpdateUserCommand(Guid id, UserUpdateDto dto)
        {
            Id = id;
            Dto = dto;
        }
    }
}
