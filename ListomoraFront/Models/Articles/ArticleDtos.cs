using System.ComponentModel.DataAnnotations;

namespace ListomoraFront.Models.Articles
{
    public class ArticleCreateUpdateDto
    {
        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "Le nom doit contenir entre 1 et 150 caractères.")]
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
