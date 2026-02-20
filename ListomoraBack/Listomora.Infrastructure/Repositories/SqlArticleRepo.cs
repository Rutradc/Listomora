using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Domain.Model;
using Listomora.Domain.Repositories;
using Listomora.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Listomora.Infrastructure.Repositories
{
    public class SqlArticleRepo : IArticleRepo
    {
        private readonly ListomoraDbContext _dbContext;

        public SqlArticleRepo(ListomoraDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteAsync(Guid id, Guid? userId = null)
        {
            Article article;
            if (userId is null)
                article = await _dbContext.Articles.SingleOrDefaultAsync(a => a.Id == id);
            else
                article = await _dbContext.Articles.SingleOrDefaultAsync(a => a.Id == id && a.CreatorId == userId);
            if (article is null)
                return false;
            _dbContext.Articles.Remove(article);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ArticleDetailsDto> GetByIdAsync(Guid id, Guid? userId = null)
        {
            if (userId is null)
                return await _dbContext.Articles.Include(a => a.User).Select(a => a.ToDetailsDto()).SingleOrDefaultAsync(a => a.Id == id);
            return await _dbContext.Articles.Where(a => a.IsPublic || a.CreatorId == userId).Include(a => a.User).Select(a => a.ToDetailsDto()).SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<ArticleDetailsDto>> GetAllAsync()
        {
            return await _dbContext.Articles.Include(a => a.User).Select(a => a.ToDetailsDto()).ToListAsync();
        }

        public async Task<IEnumerable<ArticleListDto>> GetAllPublicAsync()
        {
            return await _dbContext.Articles.Include(a => a.User).Where(a => a.IsPublic).Select(a => a.ToListDto()).ToListAsync();
        }

        public async Task<bool> InsertAsync(ArticleCreateUpdateDto article, Guid creatorId)
        {
            _dbContext.Articles.Add(article.ToEntity(creatorId));
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Guid id, ArticleCreateUpdateDto article, Guid? userId = null)
        {
            Article articleToUpdate;
            if (userId is null)
                articleToUpdate = await _dbContext.Articles.SingleOrDefaultAsync(a => a.Id == id);
            else
                articleToUpdate = await _dbContext.Articles.SingleOrDefaultAsync(a => a.Id == id && a.CreatorId == (Guid)userId);
            if (articleToUpdate is null)
                return false;
            articleToUpdate.Name = article.Name;
            articleToUpdate.IsPublic = article.IsPublic;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
