using System.Text.Json.Serialization;

namespace Listomora.Domain.Models
{
    public class ShoppingList : EntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsTemplate { get; set; }
        public bool IsDone { get; set; }
        public DateTime? DoneAt { get; set; }
        //public Guid? StoreId { get; set; }
        public Guid CreatorId { get; set; }
        [JsonIgnore]
        public ICollection<ShoppingListLine> ShoppingListLines { get; set; }
        [JsonIgnore]
        public User Creator { get; set; }
    }
}
