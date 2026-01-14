using Listomora.Domain.Model;

namespace Listomora.BLL.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegisterUser(User user);
        Task<bool> VerifyLogin(string email, string providedPassword);
    }
}
