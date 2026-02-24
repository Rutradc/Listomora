using Listomora.Application.Contracts.Persistence.Dtos;
using MediatR;

namespace Listomora.Application.Features.Articles.Queries
{
    public class GetAllArticlesQuery : IRequest<IEnumerable<ArticleDetailsDto>>
    {
    }
}
