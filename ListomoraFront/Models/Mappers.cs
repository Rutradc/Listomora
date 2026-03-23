using ListomoraFront.Models.ShoppingLists;
using MudBlazor.Charts;

namespace ListomoraFront.Models
{
    public static class Mappers
    {
        public static ShoppingListCreateDto ToCreateDto(this ShoppingListDetailsDto dto)
        {
            return new ShoppingListCreateDto()
            {
                Name = dto.Name,
                IsTemplate = dto.IsTemplate,
            };
        }
        public static ShoppingListUpdateDto ToUpdateDto(this ShoppingListDetailsDto dto)
        {
            return new ShoppingListUpdateDto()
            {
                Name = dto.Name
            };
        }
        public static ShoppingListLineCreateUpdateDto ToCreateUpdateDto(this ShoppingListLineListDto dto, Guid shoppingListId)
        {
            return new ShoppingListLineCreateUpdateDto()
            {
                ArticleId = dto.ArticleId,
                ShoppingListId = shoppingListId,
                Amount = dto.Amount,
                Unit = dto.Unit,
                Price = dto.Price,
            };
        }
    }
}
