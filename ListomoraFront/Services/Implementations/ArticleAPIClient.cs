using ListomoraFront.Models.Articles;
using ListomoraFront.Services.Interfaces;
using System.Net.Http.Json;

namespace ListomoraFront.Services.Implementations
{
    public class ArticleAPIClient : IArticleService
    {
        private readonly HttpClient _http;
        private readonly string _defaultRoute = "/api/Article/";

        public ArticleAPIClient(HttpClient http, IConfiguration config)
        {
            _http = http;
            _http.BaseAddress = new Uri(config.GetValue("BaseUrl", "https://localhost:7087"));
        }

        public async Task<List<ArticleDto>> GetAllAsync()
        {
            HttpResponseMessage response = await _http.GetAsync(_defaultRoute);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<ArticleDto>>();
        }

        public async Task<ArticleDto> GetByIdAsync(Guid id)
        {
            HttpResponseMessage response = await _http.GetAsync(_defaultRoute + id);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ArticleDto>();
        }
    }
}
