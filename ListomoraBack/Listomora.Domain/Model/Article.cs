using System.Text.Json.Serialization;

namespace Listomora.Domain.Model
{
    public class Article : EntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public Guid? CreatorId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
    }
}
