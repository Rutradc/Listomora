namespace Listomora.Domain.Model
{
    public class CreationToken
    {

        public required string TokenHash { get; set; }

        public DateTime ExpiresAt { get; set; }

        public Guid CreatedByAdminId { get; set; }
    }
}
