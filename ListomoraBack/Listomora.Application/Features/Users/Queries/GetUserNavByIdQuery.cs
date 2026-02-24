using Listomora.Application.Contracts.Persistence.Dtos;
using MediatR;

namespace Listomora.Application.Features.Users.Queries
{
    public class GetUserNavByIdQuery : IRequest<UserNavDto>
    {
        public Guid Id { get; set; }

        public GetUserNavByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
