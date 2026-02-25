using Blazored.LocalStorage;
using ListomoraFront.Models.Auth;
using ListomoraFront.Services.Interfaces;
using System.Net.Http.Json;

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

        public async void LogoutAsync()
        {
            await _localStorage.RemoveItemAsync("token");
            NotifyStateChanged();
        }

        public async Task<bool> RegisterAsync(RegisterForm form)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync(_defaultRoute + "register", form);
            return response.IsSuccessStatusCode;
        }
    }
}
