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
        public static UserProfileDto ToProfileDto(this User entity)
        {
            return new UserProfileDto(entity.FirstName, entity.LastName, entity.Email);
        }

        public static UserNavDto ToNavDto(this User entity)
        {
            return new UserNavDto(entity.FirstName, entity.LastName, entity.Role);
        }

        public static CreationToken ToEntity(this CreationTokenCreateDto dto)
        {
            return new CreationToken()
            {
                TokenHash = dto.TokenHash,
                ExpiresAt = dto.ExpiresAt,
                AdminCreatorId = dto.AdminCreatorId,
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
                CreatorName = entity.Creator.FirstName + (entity.Creator.LastName is null ? "" : " " + entity.Creator.LastName)
            };
        }
        public static ArticleListDto ToListDto(this Article entity)
        {
            return new ArticleListDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                CreatorName = entity.Creator.FirstName + (entity.Creator.LastName is null ? "" : " " + entity.Creator.LastName)
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
                CreatorName = entity.Creator.FirstName + (entity.Creator.LastName is null ? "" : " " + entity.Creator.LastName)
            };
        }
        public static IngredientListDto ToListDto(this Ingredient entity)
        {
            return new IngredientListDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                Category = entity.Category,
                CreatorName = entity.Creator.FirstName + (entity.Creator.LastName is null ? "" : " " + entity.Creator.LastName)
            };
        }
        #endregion
        #region ShoppingList
        public static ShoppingList ToEntity(this ShoppingListCreateDto dto, Guid creatorId)
        {
            return new ShoppingList()
            {
                Name = dto.Name,
                IsTemplate = dto.IsTemplate,
                CreatorId = creatorId,
            };
        }
        public static ShoppingListDetailsDto ToDetailsDto(this ShoppingList entity)
        {
            return new ShoppingListDetailsDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                IsTemplate = entity.IsTemplate,
                IsDone = entity.IsDone,
                DoneAt = entity.DoneAt,
                ShoppingListLines = entity.ShoppingListLines.Select(s => s.ToListDto()),
            };
        }
        public static ShoppingListListDto ToListDto(this ShoppingList entity)
        {
            return new ShoppingListListDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                IsTemplate = entity.IsTemplate,
                IsDone = entity.IsDone,
                DoneAt = entity.DoneAt,
            };
        }

        public static ShoppingListLineListDto ToListDto(this ShoppingListLine entity)
        {
            return new ShoppingListLineListDto()
            {
                ArticleName = entity.Article.Name,
                Amount = entity.Amount,
                Unit = entity.Unit,
                Price = entity.Price,
            };
        }
        public static ShoppingListLine ToEntity(this ShoppingListLineCreateDto dto)
        {
            return new ShoppingListLine()
            {
                ArticleId = dto.ArticleId,
                ShoppingListId = dto.ShoppingListId,
                Amount = dto.Amount,
                Unit = dto.Unit,
            };
        }
        #endregion
    }
}
