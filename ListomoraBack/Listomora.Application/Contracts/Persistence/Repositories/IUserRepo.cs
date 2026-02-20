using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Domain.Model;

namespace Listomora.Domain.Repositories
{
    public interface IUserRepo
    {
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByEmailAsync(string email);
        Task<bool> RegisterAsync(UserCreateDto user);
    }
}
