using Listomora.Domain.Model;
using MediatR;

namespace Listomora.Application.Features.Articles.Queries
{
    public class GetArticlesQuery : IRequest<IEnumerable<Article>>
    {
    }
}
