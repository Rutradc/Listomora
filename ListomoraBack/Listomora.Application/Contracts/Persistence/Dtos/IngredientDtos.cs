using Listomora.Domain.Enums;

namespace Listomora.Application.Contracts.Persistence.Dtos
{
    public record IngredientCreateUpdateDto
    (
        string Name,
        bool IsPublic,
        IngredientCategory Category
    );
}
