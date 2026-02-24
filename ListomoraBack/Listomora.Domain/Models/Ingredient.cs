using Listomora.Domain.Enums;

namespace Listomora.Domain.Models
{
    public class Ingredient : Article
    {
        public IngredientCategory Category { get; set; }
    }
}
