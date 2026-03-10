using ListomoraFront.Models.Ingredients;

namespace ListomoraFront.Services.Interfaces
{
    public interface IIngredientService
    {
        Task<IngredientDetailsDto> GetByIdAsync(Guid id);
        Task<List<IngredientListDto>> GetAllAsync();
        Task<List<IngredientDetailsDto>> GetMineAsync();
        Task<List<IngredientDetailsDto>> GetAdminAllAsync();
        Task<bool> DeleteAsync(Guid id);
        Task<bool> InsertAsync(IngredientCreateUpdateDto form);
        Task<bool> UpdateAsync(Guid id, IngredientCreateUpdateDto form);
    }
}
