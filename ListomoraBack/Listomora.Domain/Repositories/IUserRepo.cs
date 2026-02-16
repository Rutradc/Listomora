using Listomora.Domain.Model;

namespace Listomora.Domain.Repositories
{
    public interface IUserRepo
    {
        Task<User> GetAsync(string email);
        Task<bool> LoginAsync(string email, string password);
        Task<bool> RegisterAsync(User user);
    }
}
