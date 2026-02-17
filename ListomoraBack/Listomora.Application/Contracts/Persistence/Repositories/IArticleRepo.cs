using Listomora.Domain.Model;

namespace Listomora.Domain.Repositories
{
    public interface IArticleRepo
    {
        Task<Article> GetAsync(Guid id);
        Task<IEnumerable<Article>> GetAllAsync();
        Task<Article> InsertAsync(Article article);
        Task<bool> DeleteAsync(Guid id);
        Task<Article> UpdateAsync(Article article, Guid id);
    }
}
