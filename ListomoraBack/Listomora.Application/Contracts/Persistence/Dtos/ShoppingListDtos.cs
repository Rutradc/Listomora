using Listomora.Domain.Enums;
using Listomora.Domain.Models;

namespace Listomora.Application.Contracts.Persistence.Dtos
{
    public class ShoppingListLineCreateDto
    {
        public Guid ArticleId { get; set; }
        public Guid ShoppingListId { get; set; }
        public double? Amount { get; set; }
        public UnitTypeEnum? Unit { get; set; }
    }
    public class ShoppingListLineUpdateDto
    {
        public double? Amount { get; set; }
        public UnitTypeEnum? Unit { get; set; }
        public decimal? Price { get; set; }
    }
    public class ShoppingListLineListDto
    {
        public string ArticleName { get; set; }
        public double? Amount { get; set; }
        public UnitTypeEnum? Unit { get; set; }
        public decimal? Price { get; set; }
    }
    public class ShoppingListCreateDto
    {
        public string Name { get; set; }
        public bool IsTemplate { get; set; }
    }
    public class ShoppingListUpdateDto
    {
        public string Name { get; set; }
    }
    public class ShoppingListDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsTemplate { get; set; }
        public bool IsDone { get; set; }
        public DateTime? DoneAt { get; set; }
        public IEnumerable<ShoppingListLineListDto> ShoppingListLines { get; set; }
    }
    public class ShoppingListListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsTemplate { get; set; }
        public bool IsDone { get; set; }
        public DateTime? DoneAt { get; set; }
    }
}
