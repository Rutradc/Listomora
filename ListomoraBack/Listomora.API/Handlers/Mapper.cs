using Listomora.API.Dto;
using Listomora.Domain.Model;

namespace Listomora.API.Handlers
{
    public static class Mapper
    {
        public static Article ToEntity(this ArticleCreateUpdateDto dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));
            return new Article()
            {
                Name = dto.Name
            };
        }
    }
}
