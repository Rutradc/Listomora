using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Listomora.Application.Features.Users.Queries
{
    public class GetUserNavByIdQueryHandler : IRequestHandler<GetUserNavByIdQuery, UserNavDto>
    {
        private readonly IUserRepo _repo;

        public GetUserNavByIdQueryHandler(IUserRepo repo)
        {
            _repo = repo;
        }

        public async Task<UserNavDto> Handle(GetUserNavByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetNavByIdAsync(request.Id);
        }
    }
}
