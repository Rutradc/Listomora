using Listomora.BLL.Services.Interfaces;
using Listomora.Domain.Model;
using Listomora.Domain.Repositories;

namespace Listomora.BLL.Services.Implementations
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepo _repo;

        public ArticleService(IArticleRepo repo)
        {
            _repo = repo;
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            return _repo.DeleteAsync(id);
        }

        public Task<IEnumerable<Article>> GetAllAsync()
        {
            return _repo.GetAllAsync();
        }

        public Task<Article> GetAsync(Guid id)
        {
            return _repo.GetAsync(id);
        }

        public Task<Article> InsertAsync(Article article)
        {
            return _repo.InsertAsync(article);
        }

        public Task<Article> UpdateAsync(Article article, Guid id)
        {
            return _repo.UpdateAsync(article, id);
        }
    }
}
