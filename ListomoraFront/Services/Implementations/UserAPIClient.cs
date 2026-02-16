using ListomoraFront.Models.Users;
using ListomoraFront.Services.Interfaces;
using System.Net.Http.Json;

namespace ListomoraFront.Services.Implementations
{
    public class UserAPIClient : IUserService
    {
        private readonly HttpClient _http;
        private readonly string _defaultRoute = "/api/User/";

        public UserAPIClient(HttpClient http, IConfiguration config)
        {
            _http = http;
            _http.BaseAddress = new Uri(config.GetValue("BaseUrl", "https://localhost:7193"));
        }

        public async Task<UserNav> GetNavAsync()
        {
            try
            {
                HttpResponseMessage response = await _http.GetAsync(_defaultRoute + "header");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<UserNav>();
            }
            catch
            {
                return null;
            }
        }

        public async Task<UserProfile> GetProfileAsync()
        {
            try
            {
                HttpResponseMessage response = await _http.GetAsync(_defaultRoute);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<UserProfile>();
            }
            catch
            {
                return null;
            }
        }
    }
}
