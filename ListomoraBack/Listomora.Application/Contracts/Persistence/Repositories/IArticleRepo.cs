using Listomora.Application.Contracts.Persistence.Dtos;

namespace Listomora.Application.Contracts.Persistence.Repositories
{
    public interface IArticleRepo
    {
        Task<ArticleDetailsDto> GetByIdAsync(Guid id, Guid? userId = null);
        Task<IEnumerable<ArticleDetailsDto>> GetAllAsync();
        Task<IEnumerable<ArticleListDto>> GetAllPublicAsync();
        Task<IEnumerable<ArticleListDto>> GetPublicAndMineAsync(Guid userId);
        Task<IEnumerable<ArticleDetailsDto>> GetMineAsync(Guid userId);
        Task<bool> InsertAsync(ArticleCreateUpdateDto article, Guid creatorId);
        Task<bool> DeleteAsync(Guid id, Guid? userId = null);
        Task<bool> UpdateAsync(Guid id, ArticleCreateUpdateDto article, Guid? userId = null);
    }
}
