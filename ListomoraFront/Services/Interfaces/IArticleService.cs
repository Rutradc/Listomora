using ListomoraFront.Models.Articles;

namespace ListomoraFront.Services.Interfaces
{
    public interface IArticleService
    {
        Task<ArticleDetailsDto> GetByIdAsync(Guid id);
        Task<List<ArticleListDto>> GetAllAsync();
    }
}
