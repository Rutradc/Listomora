using Listomora.BLL.Services.Interfaces;
using Listomora.Domain.Model;
using Listomora.Domain.Repositories;

namespace Listomora.BLL.Services.Implementations
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepo _repo;

        public IngredientService(IIngredientRepo repo)
        {
            _repo = repo;
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            return _repo.DeleteAsync(id);
        }

        public Task<IEnumerable<Ingredient>> GetAllAsync()
        {
            return _repo.GetAllAsync();
        }

        public Task<Ingredient> GetAsync(Guid id)
        {
            return _repo.GetAsync(id);
        }

        public Task<Ingredient> InsertAsync(Ingredient ingredient)
        {
            return _repo.InsertAsync(ingredient);
        }

        public Task<Ingredient> UpdateAsync(Ingredient ingredient, Guid id)
        {
            return _repo.UpdateAsync(ingredient, id);
        }
    }
}
