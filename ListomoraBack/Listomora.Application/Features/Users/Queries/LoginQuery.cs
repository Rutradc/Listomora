using Listomora.Application.Contracts.Persistence.Dtos;
using MediatR;

namespace Listomora.Application.Features.Users.Queries
{
    public class LoginQuery : IRequest<UserForToken>
    {
        public UserCredsDto Credentials { get; set; }

        public LoginQuery(UserCredsDto credentials)
        {
            Credentials = credentials;
        }
    }
}
