using System.Text.Json.Serialization;

namespace Listomora.Domain.Models
{
    public class Article : EntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public Guid? CreatorId { get; set; }
        [JsonIgnore]
        public User? Creator { get; set; }
    }
}
