namespace Listomora.Application.Contracts.Persistence.Dtos
{
    public class ArticleCreateUpdateDto
    {
        public string Name { get; set; }
        public bool IsPublic { get; set; }
    };
    public class ArticleDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public string CreatorName { get; set; }
    }
    public class ArticleListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CreatorName { get; set; }
    }
}
