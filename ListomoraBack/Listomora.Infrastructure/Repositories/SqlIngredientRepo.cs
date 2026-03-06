using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Application.Contracts.Persistence.Repositories;
using Listomora.Domain.Models;
using Listomora.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Listomora.Infrastructure.Repositories
{
    public class SqlIngredientRepo : IIngredientRepo
    {
        private readonly ListomoraDbContext _dbContext;

        public SqlIngredientRepo(ListomoraDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteAsync(Guid id, Guid? userId = null)
        {
            Ingredient ingredient;
            if (userId is null)
                ingredient = await _dbContext.Ingredients.SingleOrDefaultAsync(a => a.Id == id);
            else
                ingredient = await _dbContext.Ingredients.SingleOrDefaultAsync(a => a.Id == id && a.CreatorId == userId);
            if (ingredient is null)
                return false;
            _dbContext.Ingredients.Remove(ingredient);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<IngredientDetailsDto>> GetAllAsync()
        {
            return await _dbContext.Ingredients.Include(i => i.Creator).Select(i => i.ToDetailsDto()).ToListAsync();
        }

        public async Task<IEnumerable<IngredientListDto>> GetAllPublicAsync()
        {
            return await _dbContext.Ingredients.Include(i => i.Creator).Where(i => i.IsPublic).Select(i => i.ToListDto()).ToListAsync();
        }

        public async Task<IngredientDetailsDto> GetByIdAsync(Guid id, Guid? userId = null)
        {
            if (userId is null)
                return (await _dbContext.Ingredients.Include(i => i.Creator).SingleOrDefaultAsync(i => i.Id == id)).ToDetailsDto();
            return (await _dbContext.Ingredients.Where(i => i.IsPublic || i.CreatorId == userId).Include(i => i.Creator).SingleOrDefaultAsync(i => i.Id == id)).ToDetailsDto();
        }

        public async Task<bool> InsertAsync(IngredientCreateUpdateDto ingredient, Guid creatorId)
        {
            _dbContext.Ingredients.Add(ingredient.ToEntity(creatorId));
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Guid id, IngredientCreateUpdateDto ingredient, Guid? userId = null)
        {
            Ingredient ingredientToUpdate;
            if (userId is null)
                ingredientToUpdate = await _dbContext.Ingredients.SingleOrDefaultAsync(a => a.Id == id);
            else
                ingredientToUpdate = await _dbContext.Ingredients.SingleOrDefaultAsync(a => a.Id == id && a.CreatorId == (Guid)userId);
            if (ingredientToUpdate is null)
                return false;
            ingredientToUpdate.Name = ingredient.Name;
            ingredientToUpdate.IsPublic = ingredient.IsPublic;
            ingredientToUpdate.Category = ingredient.Category;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<IngredientListDto>> GetPublicAndMineAsync(Guid userId)
        {
            return await _dbContext.Ingredients.Include(a => a.Creator).Where(a => a.IsPublic || a.CreatorId == userId).Select(a => a.ToListDto()).ToListAsync();
        }

        public async Task<IEnumerable<IngredientDetailsDto>> GetMineAsync(Guid userId)
        {
            return await _dbContext.Ingredients.Include(a => a.Creator).Where(a => a.CreatorId == userId).Select(a => a.ToDetailsDto()).ToListAsync();
        }
    }
}
