using Listomora.Domain.Enums;

namespace Listomora.Application.Contracts.Persistence.Dtos
{
    public class ShoppingListLineArticleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class ShoppingListLinesUpdateDto
    {
        public List<ShoppingListLineCreateUpdateDto> AddedLines { get; set; }
        public List<ShoppingListLineCreateUpdateDto> UpdatedLines { get; set; }
        public List<Guid> RemovedLinesArticleIds { get; set; }
        public Guid ShoppingListId { 
            get
            {
                return AddedLines.FirstOrDefault().ShoppingListId;
            } 
        }

        public ShoppingListLinesUpdateDto()
        {
            AddedLines = new List<ShoppingListLineCreateUpdateDto>();
            UpdatedLines = new List<ShoppingListLineCreateUpdateDto>();
            RemovedLinesArticleIds = new List<Guid>();
        }
    }
    public class ShoppingListLineCreateUpdateDto
    {
        public Guid ArticleId { get; set; }
        public Guid OriginArticleId { get; set; }
        public Guid ShoppingListId { get; set; }
        public double? Amount { get; set; }
        public UnitTypeEnum? Unit { get; set; }
        public decimal? Price { get; set; }
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
