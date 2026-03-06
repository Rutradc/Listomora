using ListomoraFront.Models.Auth;
using ListomoraFront.Models.Users;

namespace ListomoraFront.Services.Interfaces
{
    public interface IAuthService
    {
        public event Action? OnAuthStateChanged;
        Task<bool> LoginAsync(LoginForm form);
        Task<bool> RegisterAsync(RegisterForm form);
        void LogoutAsync();
        Task<bool> UpdateAsync(UserUpdateDto dto);
    }
}
