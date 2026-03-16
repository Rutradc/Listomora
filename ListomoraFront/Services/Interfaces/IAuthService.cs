using ListomoraFront.Models.Auth;
using ListomoraFront.Models.Users;

namespace ListomoraFront.Services.Interfaces
{
    public interface IAuthService
    {
        public event Action? OnAuthStateChanged;
        Task<bool> LoginAsync(LoginForm form);
        Task<bool> RegisterAsync(RegisterForm form);
        Task LogoutAsync();
        Task<bool> UpdateAsync(UserUpdateDto dto);
        Task<string> GenerateCreationTokenAsync(CreationTokenCreateDto dto);
        Task<bool> CheckCreationAsync(string creationToken);
    }
}
