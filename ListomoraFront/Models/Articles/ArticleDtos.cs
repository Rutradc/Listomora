namespace ListomoraFront.Models.Articles
{
    public class ArticleDto : EntityBase
    {
        public ArticleDto()
        {
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public Guid? CreatorId { get; set; }
        //[JsonIgnore]
        //public User? User { get; set; }
    }

    public class ArticleCreateUpdateDto
    {
        public ArticleCreateUpdateDto()
        {
        }

        public string Name { get; set; }
        public bool IsPublic { get; set; }
    }
}
