using Listomora.Domain.Enums;

namespace Listomora.API.Dto
{
    public record IngredientCreateUpdateDto
    (
        string Name,
        bool IsPublic,
        IngredientCategory Category
    );
}
