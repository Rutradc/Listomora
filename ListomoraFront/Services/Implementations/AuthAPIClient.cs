using ListomoraFront.Models.Auth;
using ListomoraFront.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace ListomoraFront.Services.Implementations
{
    public class AuthAPIClient : IAuthService
    {
        private readonly HttpClient _http;
        private readonly string _defaultRoute = "/api/Auth/";
        public event Action? OnAuthStateChanged;

        public AuthAPIClient(HttpClient http, IConfiguration config)
        {
            _http = http;
            _http.BaseAddress = new Uri(config.GetValue("BaseUrl", "https://localhost:7193"));
        }

        private void NotifyStateChanged()
        {
            // OnAuthStateChanged est invoqué pour informer les composants abonnés
            // que l'état d'authentification a changé
            OnAuthStateChanged?.Invoke();
        }

        public async Task<string> GetRole()
        {
            HttpResponseMessage response = await _http.GetAsync(_defaultRoute + "role");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<bool> IsAuthenticated()
        {
            HttpResponseMessage response = await _http.GetAsync(_defaultRoute);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> LoginAsync(LoginForm form)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync(_defaultRoute + "login", form);
            NotifyStateChanged();
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> LogoutAsync()
        {
            HttpResponseMessage response = await _http.PostAsync(_defaultRoute + "logout", null);
            NotifyStateChanged();
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RegisterAsync(RegisterForm form)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync(_defaultRoute + "register", form);
            return response.IsSuccessStatusCode;
        }
    }
}
