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
        }

        public async Task<UserNav> GetNavAsync()
        {
            try
            {
                HttpResponseMessage response = await _http.GetAsync(_defaultRoute + "nav");
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
                HttpResponseMessage response = await _http.GetAsync(_defaultRoute + "profile");
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
