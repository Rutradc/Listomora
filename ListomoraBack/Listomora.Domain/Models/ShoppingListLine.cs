using Listomora.Domain.Enums;
using System.Text.Json.Serialization;

namespace Listomora.Domain.Models
{
    public class ShoppingListLine : EntityBase
    {
        public double? Amount { get; set; }
        public UnitTypeEnum? Unit { get; set; }
        public decimal? Price { get; set; }
        public Guid ArticleId { get; set; }
        public Guid ShoppingListId { get; set; }
        // TODO : implémenter Order comme ordre d'affichage dans la liste de courses
        // public int Order { get; set; }
        [JsonIgnore]
        public Article Article { get; set; }
        [JsonIgnore]
        public ShoppingList ShoppingList { get; set; }
    }
}
