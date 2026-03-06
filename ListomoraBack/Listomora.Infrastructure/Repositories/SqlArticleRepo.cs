using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Application.Contracts.Persistence.Repositories;
using Listomora.Domain.Models;
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
                return (await _dbContext.Articles.Include(a => a.Creator).SingleOrDefaultAsync(a => a.Id == id)).ToDetailsDto();
            return (await _dbContext.Articles.Where(a => a.IsPublic || a.CreatorId == userId).Include(a => a.Creator).SingleOrDefaultAsync(a => a.Id == id)).ToDetailsDto();
        }

        public async Task<IEnumerable<ArticleDetailsDto>> GetAllAsync()
        {
            return await _dbContext.Articles.Include(a => a.Creator).Select(a => a.ToDetailsDto()).ToListAsync();
        }

        public async Task<IEnumerable<ArticleListDto>> GetAllPublicAsync()
        {
            return await _dbContext.Articles.Include(a => a.Creator).Where(a => a.IsPublic).Select(a => a.ToListDto()).ToListAsync();
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

        public async Task<IEnumerable<ArticleListDto>> GetPublicAndMineAsync(Guid userId)
        {
            return await _dbContext.Articles.Include(a => a.Creator).Where(a => a.IsPublic || a.CreatorId == userId).Select(a => a.ToListDto()).ToListAsync();
        }

        public async Task<IEnumerable<ArticleDetailsDto>> GetMineAsync(Guid userId)
        {
            return await _dbContext.Articles.Include(a => a.Creator).Where(a => a.CreatorId == userId).Select(a => a.ToDetailsDto()).ToListAsync();
        }
    }
}
