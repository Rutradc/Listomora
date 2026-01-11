using Listomora.Domain.Enums;

namespace Listomora.Domain.Model
{
    public class Ingredient : Article
    {
        public IngredientCategory Category { get; set; }
    }
}
