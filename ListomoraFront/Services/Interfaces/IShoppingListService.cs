using ListomoraFront.Models.ShoppingLists;

namespace ListomoraFront.Services.Interfaces
{
    public interface IShoppingListService
    {
        Task<ShoppingListDetailsDto> GetByIdAsync(Guid id);
        Task<List<ShoppingListListDto>> GetAllAsync();
        Task<List<ShoppingListListDto>> GetMineAsync();
        Task<bool> DeleteAsync(Guid id);
        Task<Guid> InsertAsync(ShoppingListCreateDto form);
        Task<bool> UpdateAsync(Guid id, ShoppingListUpdateDto form);
        Task<bool> UpdateLinesAsync(ShoppingListLinesUpdateDto dto, Guid shoppingListId);
        Task<bool> Complete(Guid id);
    }
}
