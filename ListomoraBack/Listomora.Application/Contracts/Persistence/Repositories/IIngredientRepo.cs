using Listomora.Application.Contracts.Persistence.Dtos;

namespace Listomora.Application.Contracts.Persistence.Repositories
{
    public interface IIngredientRepo
    {
        Task<IngredientDetailsDto> GetByIdAsync(Guid id, Guid? userId = null);
        Task<IEnumerable<IngredientDetailsDto>> GetAllAsync();
        Task<IEnumerable<IngredientListDto>> GetAllPublicAsync();
        Task<IEnumerable<IngredientListDto>> GetPublicAndMineAsync(Guid userId);
        Task<IEnumerable<IngredientDetailsDto>> GetMineAsync(Guid userId);
        Task<bool> InsertAsync(IngredientCreateUpdateDto ingredient, Guid creatorId);
        Task<bool> DeleteAsync(Guid id, Guid? userId = null);
        Task<bool> UpdateAsync(Guid id, IngredientCreateUpdateDto ingredient, Guid? userId = null);
    }
}
