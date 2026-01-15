namespace Listomora.Domain.Model
{
    public class User : EntityBase
    {
        public Guid Id { get; private set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime? DisableDate { get; set; }
        public ICollection<Article> CreatedArticles { get; set; }
    }
}
