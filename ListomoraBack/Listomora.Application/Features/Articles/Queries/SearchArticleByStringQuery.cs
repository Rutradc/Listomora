using Listomora.Application.Contracts.Persistence.Dtos;
using MediatR;

namespace Listomora.Application.Features.Articles.Queries
{
    public class SearchArticleByStringQuery : IRequest<IEnumerable<ShoppingListLineArticleDto>>
    {
        public string SearchString { get; set; }
        public Guid UserId { get; set; }
        public bool IsAdmin { get; set; }

        public SearchArticleByStringQuery(string searchString, Guid userId)
        {
            SearchString = searchString;
            UserId = userId;
            IsAdmin = false;
        }

        public SearchArticleByStringQuery(string searchString)
        {
            SearchString = searchString;
            IsAdmin = true;
        }
    }
}
