using Listomora.Domain.Models;
using MediatR;

namespace Listomora.Application.Features.Users.Queries
{
    public class CheckCreationTokenQuery : IRequest<bool>
    {
        public string CreationToken { get; set; }

        public CheckCreationTokenQuery(string creationToken)
        {
            CreationToken = creationToken;
        }
    }
}
