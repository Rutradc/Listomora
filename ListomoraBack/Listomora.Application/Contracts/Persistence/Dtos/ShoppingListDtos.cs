using Listomora.Domain.Enums;

namespace Listomora.Application.Contracts.Persistence.Dtos
{
    public class ShoppingListLineArticleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class ShoppingListLineCreateUpdateDto
    {
        public Guid ArticleId { get; set; }
        public Guid OriginArticleId { get; set; }
        public Guid ShoppingListId { get; set; }
        public double? Amount { get; set; }
        public UnitTypeEnum? Unit { get; set; }
        public decimal? Price { get; set; }
        public bool IsNew { get; set; } = true;
        public bool IsModified { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
    }
    public class ShoppingListLineListDto
    {
        public Guid ArticleId { get; set; }
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
