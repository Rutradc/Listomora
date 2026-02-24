using Listomora.Application.Contracts.Persistence.Dtos;
using MediatR;

namespace Listomora.Application.Features.Ingredients.Queries
{
    public class GetIngredientByIdQuery : IRequest<IngredientDetailsDto>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public bool IsAdmin { get; set; }

        public GetIngredientByIdQuery(Guid id, Guid userId)
        {
            Id = id;
            UserId = userId;
            IsAdmin = false;
        }

        public GetIngredientByIdQuery(Guid id)
        {
            Id = id;
            IsAdmin = true;
        }
    }
}
