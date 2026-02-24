using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Domain.Models;

namespace Listomora.Application.Contracts.Persistence.Repositories
{
    public interface IUserRepo
    {
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByEmailAsync(string email);
        Task<bool> RegisterAsync(UserCreateDto user);
    }
}
