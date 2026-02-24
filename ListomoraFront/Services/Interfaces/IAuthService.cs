using ListomoraFront.Models.Auth;

namespace ListomoraFront.Services.Interfaces
{
    public interface IAuthService
    {
        public event Action? OnAuthStateChanged;
        Task<bool> LoginAsync(LoginForm form);
        Task<bool> RegisterAsync(RegisterForm form);
        void LogoutAsync();
    }
}
