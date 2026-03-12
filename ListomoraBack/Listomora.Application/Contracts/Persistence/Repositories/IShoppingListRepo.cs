using Listomora.Application.Contracts.Persistence.Dtos;

namespace Listomora.Application.Contracts.Persistence.Repositories
{
    public interface IShoppingListRepo
    {
        Task<ShoppingListDetailsDto> GetByIdAsync(Guid id, Guid? userId);
        Task<IEnumerable<ShoppingListListDto>> GetAllAsync();
        Task<IEnumerable<ShoppingListListDto>> GetMineAsync(Guid creatorId);
        Task<bool> InsertAsync(ShoppingListCreateUpdateDto dto, Guid creatorId);
        Task<bool> InsertLineAsync(ShoppingListLineCreateDto dto, Guid creatorId);
        Task<bool> UpdateAsync(Guid id, ShoppingListCreateUpdateDto dto, Guid? userId);
        Task<bool> UpdateLineAsync(Guid articleId, Guid shoppingListId, ShoppingListLineUpdateDto dto);
        Task<bool> DeleteAsync(Guid id, Guid? userId);
        Task<bool> DeleteLineAsync(Guid articleId, Guid shoppingListId);
        Task<bool> CompleteShoppingList(Guid id, bool isDone, Guid? userId);
    }
}
