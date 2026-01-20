using Listomora.Domain.Model;
using Listomora.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Listomora.DAL.Repositories
{
    public class SqlIngredientRepo : IIngredientRepo
    {
        private readonly ListomoraDbContext _dbContext;

        public SqlIngredientRepo(ListomoraDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Ingredient ingredient = await _dbContext.Ingredients.SingleOrDefaultAsync(a => a.Id == id);
            if (ingredient is null)
                return false;
            _dbContext.Ingredients.Remove(ingredient);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Ingredient>> GetAllAsync()
        {
            return await _dbContext.Ingredients.ToListAsync();
        }

        public async Task<Ingredient> GetAsync(Guid id)
        {
            return await _dbContext.Ingredients.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Ingredient> InsertAsync(Ingredient ingredient)
        {
            _dbContext.Ingredients.Add(ingredient);
            await _dbContext.SaveChangesAsync();
            return ingredient;
        }

        public async Task<Ingredient> UpdateAsync(Ingredient ingredient, Guid id)
        {
            Ingredient ingredientToUpdate = await _dbContext.Ingredients.FirstOrDefaultAsync(a => a.Id == id);
            if (ingredientToUpdate is null)
                return null;
            ingredientToUpdate.Name = ingredient.Name;
            ingredientToUpdate.IsPublic = ingredient.IsPublic;
            ingredientToUpdate.Category = ingredient.Category;
            await _dbContext.SaveChangesAsync();
            return ingredientToUpdate;
        }
    }
}
