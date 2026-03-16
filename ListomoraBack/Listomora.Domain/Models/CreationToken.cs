using System.Text.Json.Serialization;

namespace Listomora.Domain.Models
{
    public class CreationToken : EntityBase
    {
        public string TokenHash { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime? UsedAt { get; set; }
        public Guid AdminCreatorId { get; set; }
        [JsonIgnore]
        public User AdminCreator { get; set; }
    }
}
