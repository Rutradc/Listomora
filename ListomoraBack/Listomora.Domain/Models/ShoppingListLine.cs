using System.Text.Json.Serialization;

namespace Listomora.Domain.Models
{
    public class ShoppingListLine : EntityBase
    {
        public double Amount { get; set; }
        public string Unit { get; set; } // ou UnitTypeEnum
        public decimal? Price { get; set; }
        public Guid ArticleId { get; set; }
        public Guid ShoppingListId { get; set; }
        [JsonIgnore]
        public Article Article { get; set; }
        [JsonIgnore]
        public ShoppingList ShoppingList { get; set; }
    }
}
