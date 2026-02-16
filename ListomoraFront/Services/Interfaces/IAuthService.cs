using ListomoraFront.Models.Auth;

namespace ListomoraFront.Services.Interfaces
{
    public interface IAuthService
    {
        public event Action? OnAuthStateChanged;
        Task<bool> IsAuthenticated();
        Task<bool> LoginAsync(LoginForm form);
        Task<bool> RegisterAsync(RegisterForm form);
        Task<bool> LogoutAsync();
        Task<string> GetRole();
    }
}
