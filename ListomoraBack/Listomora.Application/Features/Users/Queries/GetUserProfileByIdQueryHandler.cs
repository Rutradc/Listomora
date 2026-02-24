using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.Users.Queries
{
    public class GetUserProfileByIdQueryHandler : IRequestHandler<GetUserProfileByIdQuery, UserProfileDto>
    {
        private readonly IUserRepo _repo;

        public GetUserProfileByIdQueryHandler(IUserRepo repo)
        {
            _repo = repo;
        }

        public async Task<UserProfileDto> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetProfileByIdAsync(request.Id);
        }
    }
}
