using Listomora.Application.Contracts.Persistence.Dtos;
using MediatR;

namespace Listomora.Application.Features.Users.Queries
{
    public class GetUserProfileByIdQuery : IRequest<UserProfileDto>
    {
        public Guid Id { get; set; }

        public GetUserProfileByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
