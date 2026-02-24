using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Domain.Models;

namespace Listomora.Infrastructure.Mappers
{
    internal static class Mappers
    {
        #region User
        public static User ToEntity(this UserCreateDto dto)
        {
            return new User()
            {
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Password = dto.Password
            };
        }
        #endregion
        #region Article
        public static Article ToEntity(this ArticleCreateUpdateDto dto, Guid? creatorId = null)
        {
            if (creatorId != null)
            {
                return new Article()
                {
                    Name = dto.Name,
                    IsPublic = dto.IsPublic,
                    CreatorId = creatorId
                };
            }
            return new Article()
            {
                Name = dto.Name,
                IsPublic = dto.IsPublic
            };
        }
        public static ArticleDetailsDto ToDetailsDto(this Article entity)
        {
            return new ArticleDetailsDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                IsPublic = entity.IsPublic,
                CreatorName = entity.User.FirstName + (entity.User.LastName is null ? "" : " " + entity.User.LastName)
            };
        }
        public static ArticleListDto ToListDto(this Article entity)
        {
            return new ArticleListDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                CreatorName = entity.User.FirstName + (entity.User.LastName is null ? "" : " " + entity.User.LastName)
            };
        }
        #endregion
        #region Ingredient
        public static Ingredient ToEntity(this IngredientCreateUpdateDto dto, Guid? creatorId = null)
        {
            if (creatorId != null)
            {
                return new Ingredient()
                {
                    Name = dto.Name,
                    IsPublic = dto.IsPublic,
                    Category = dto.Category,
                    CreatorId = creatorId
                };
            }
            return new Ingredient()
            {
                Name = dto.Name,
                IsPublic = dto.IsPublic,
                Category = dto.Category
            };
        }
        public static IngredientDetailsDto ToDetailsDto(this Ingredient entity)
        {
            return new IngredientDetailsDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                IsPublic = entity.IsPublic,
                Category = entity.Category,
                CreatorName = entity.User.FirstName + (entity.User.LastName is null ? "" : " " + entity.User.LastName)
            };
        }
        public static IngredientListDto ToListDto(this Ingredient entity)
        {
            return new IngredientListDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                Category = entity.Category,
                CreatorName = entity.User.FirstName + (entity.User.LastName is null ? "" : " " + entity.User.LastName)
            };
        }
        #endregion
    }
}
