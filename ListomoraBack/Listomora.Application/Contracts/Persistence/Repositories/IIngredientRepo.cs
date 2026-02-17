using Listomora.Domain.Model;

namespace Listomora.Domain.Repositories
{
    public interface IIngredientRepo
    {
        Task<Ingredient> GetAsync(Guid id);
        Task<IEnumerable<Ingredient>> GetAllAsync();
        Task<Ingredient> InsertAsync(Ingredient ingredient);
        Task<bool> DeleteAsync(Guid id);
        Task<Ingredient> UpdateAsync(Ingredient ingredient, Guid id);
    }
}
