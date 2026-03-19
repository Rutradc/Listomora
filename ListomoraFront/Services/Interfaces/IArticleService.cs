using ListomoraFront.Models.Articles;
using ListomoraFront.Models.ShoppingLists;

namespace ListomoraFront.Services.Interfaces
{
    public interface IArticleService
    {
        Task<ArticleDetailsDto> GetByIdAsync(Guid id);
        Task<List<ArticleListDto>> GetAllAsync();
        Task<List<ArticleDetailsDto>> GetMineAsync();
        Task<List<ArticleDetailsDto>> GetAdminAllAsync();
        Task<bool> DeleteAsync(Guid id);
        Task<bool> InsertAsync(ArticleCreateUpdateDto form);
        Task<bool> UpdateAsync(Guid id, ArticleCreateUpdateDto form);
        Task<List<ShoppingListLineArticleDto>> Search(string searchString);
    }
}
