using Listomora.Domain.Model;

namespace Listomora.BLL.Services.Interfaces
{
    public interface IIngredientService
    {
        Task<Ingredient> GetAsync(Guid id);
        Task<IEnumerable<Ingredient>> GetAllAsync();
        Task<Ingredient> InsertAsync(Ingredient ingredient);
        Task<bool> DeleteAsync(Guid id);
        Task<Ingredient> UpdateAsync(Ingredient ingredient, Guid id);
    }
}
