namespace Listomora.Domain.Models
{
    public class CreationToken : EntityBase
    {

        public required string TokenHash { get; set; }

        public DateTime ExpiresAt { get; set; }

        public Guid CreatedByAdminId { get; set; }
    }
}
