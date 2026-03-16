using Blazored.LocalStorage;
using ListomoraFront.Models.Auth;
using ListomoraFront.Models.Users;
using ListomoraFront.Services.Interfaces;
using System.Net.Http.Json;
using static MudBlazor.CategoryTypes;

namespace ListomoraFront.Services.Implementations
{
    public class AuthAPIClient : IAuthService
    {
        private readonly HttpClient _http;
        private readonly string _defaultRoute = "/api/Auth/";
        public event Action? OnAuthStateChanged;
        private readonly ILocalStorageService _localStorage;

        public AuthAPIClient(HttpClient http, IConfiguration config, ILocalStorageService localStorage)
        {
            _http = http;
            _localStorage = localStorage;
        }

        private void NotifyStateChanged()
        {
            // OnAuthStateChanged est invoqué pour informer les composants abonnés
            // que l'état d'authentification a changé
            OnAuthStateChanged?.Invoke();
        }

        public async Task<bool> LoginAsync(LoginForm form)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync(_defaultRoute + "login", form);
            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();
                await _localStorage.SetItemAsync("token", token);
                NotifyStateChanged();
                return true;
            }
            return false;
        }

        public async Task LogoutAsync()
        {
            await _localStorage.RemoveItemAsync("token");
            NotifyStateChanged();
        }

        public async Task<bool> RegisterAsync(RegisterForm form)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync(_defaultRoute + "register", form);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(UserUpdateDto dto)
        {
            try
            {
                HttpResponseMessage response = await _http.PatchAsJsonAsync("/api/User", dto);
                NotifyStateChanged();
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<string> GenerateCreationTokenAsync(CreationTokenCreateDto dto)
        {
            DateTime expiresAt = (DateTime)(((DateTime)(dto.ExpirationDate)).Date + dto.ExpirationTime);
            try
            {
                HttpResponseMessage response = await _http.PostAsJsonAsync(_defaultRoute + "createcreationtoken", expiresAt);
                return await response.Content.ReadAsStringAsync();
            }
            catch
            {
                return null;
            }
        }

        public Task<bool> CheckCreationAsync(string creationToken)
        {
            throw new NotImplementedException();
        }
    }
}
