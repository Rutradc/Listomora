using Listomora.Domain.Enums;
using System.Text.Json.Serialization;

namespace Listomora.Domain.Models
{
    public class User : EntityBase
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserRole? Role { get; set; }
        public DateTime? DisableDate { get; set; }
        [JsonIgnore]
        public ICollection<Article> CreatedArticles { get; set; }
        [JsonIgnore]
        public ICollection<Ingredient> CreatedIngredients { get; set; }
    }
}
