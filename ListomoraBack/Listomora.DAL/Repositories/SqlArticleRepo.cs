using Listomora.Domain.Model;
using Listomora.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Listomora.DAL.Repositories
{
    public class SqlArticleRepo : IArticleRepo
    {
        private readonly ListomoraDbContext _dbContext;

        public SqlArticleRepo(ListomoraDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Article article = await _dbContext.Articles.SingleOrDefaultAsync(a => a.Id == id);
            if (article is null)
                return false;
            _dbContext.Articles.Remove(article);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Article> GetAsync(Guid id)
        {
            return await _dbContext.Articles.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await _dbContext.Articles.ToListAsync();
        }

        public async Task<Article> InsertAsync(Article article)
        {
            _dbContext.Articles.Add(article);
            await _dbContext.SaveChangesAsync();
            return article;
        }

        public async Task<Article> UpdateAsync(Article article, Guid id)
        {
            Article articleToUpdate = await _dbContext.Articles.FirstOrDefaultAsync(a => a.Id == id);
            if (articleToUpdate is null)
                return null;
            articleToUpdate.Name = article.Name;
            await _dbContext.SaveChangesAsync();
            return articleToUpdate;
        }
    }
}
