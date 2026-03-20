using Listomora.Application.Contracts.Persistence.Dtos;
using MediatR;

namespace Listomora.Application.Features.Users.Commands
{
    public class CreateCreationTokenCommand : IRequest<Unit>
    {
        public CreationTokenCreateDto Dto { get; set; }

        public CreateCreationTokenCommand(CreationTokenCreateDto dto)
        {
            Dto = dto;
        }
    }
}
