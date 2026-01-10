using Listomora.Domain.Model;

namespace Listomora.BLL.Services.Interfaces
{
    public interface IArticleService
    {
        Task<Article> GetAsync(Guid id);
        Task<IEnumerable<Article>> GetAllAsync();
        Task<Article> InsertAsync(Article article);
        Task<bool> DeleteAsync(Guid id);
        Task<Article> UpdateAsync(Article article, Guid id);
    }
}
