using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Domain.Model;

namespace Listomora.Infrastructure.Mappers
{
    internal static class Mappers
    {
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
    }
}
