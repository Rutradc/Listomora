using Listomora.Application.Contracts.Persistence.Dtos;

namespace Listomora.Application.Contracts.Persistence.Repositories
{
    public interface IShoppingListRepo
    {
        Task<ShoppingListDetailsDto> GetByIdAsync(Guid id, Guid? userId = null);
        Task<IEnumerable<ShoppingListListDto>> GetAllAsync();
        Task<IEnumerable<ShoppingListListDto>> GetMineAsync(Guid creatorId);
        Task<Guid> InsertAsync(ShoppingListCreateDto dto, Guid creatorId);
        Task<bool> InsertLineAsync(ShoppingListLineCreateDto dto);
        Task<bool> UpdateAsync(Guid id, ShoppingListUpdateDto dto, Guid? userId = null);
        Task<bool> UpdateLineAsync(Guid articleId, Guid shoppingListId, ShoppingListLineUpdateDto dto);
        Task<bool> DeleteAsync(Guid id, Guid? userId = null);
        Task<bool> DeleteLineAsync(Guid articleId, Guid shoppingListId);
        Task<bool> CompleteShoppingList(Guid id, bool isDone, Guid? userId = null);
    }
}
