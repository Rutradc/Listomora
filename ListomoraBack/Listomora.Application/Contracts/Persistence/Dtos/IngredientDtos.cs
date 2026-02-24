
using Listomora.Domain.Enums;

namespace Listomora.Application.Contracts.Persistence.Dtos
{
    public class IngredientCreateUpdateDto
    {
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public IngredientCategory Category { get; set; }
    };
    public class IngredientDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public IngredientCategory Category { get; set; }
        public string CreatorName { get; set; }
    }
    public class IngredientListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IngredientCategory Category { get; set; }
        public string CreatorName { get; set; }
    }
}
