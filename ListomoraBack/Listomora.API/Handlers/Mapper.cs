using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Domain.Models;

namespace Listomora.API.Handlers
{
    public static class Mapper
    {
        public static Article ToEntity(this ArticleCreateUpdateDto dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));
            return new Article()
            {
                Name = dto.Name,
                IsPublic = dto.IsPublic,
            };
        }
        public static Ingredient ToEntity(this IngredientCreateUpdateDto dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));
            return new Ingredient()
            {
                Name = dto.Name,
                IsPublic = dto.IsPublic,
                Category = dto.Category 
            };
        }
        public static User ToEntity(this UserCreateDto dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));
            return new User()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = dto.Password
            };
        }
    }
}
