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
        }

        public async Task<List<ArticleListDto>> GetAllAsync()
        {
            HttpResponseMessage response = await _http.GetAsync(_defaultRoute);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<ArticleListDto>>();
        }

        public async Task<ArticleDetailsDto> GetByIdAsync(Guid id)
        {
            HttpResponseMessage response = await _http.GetAsync(_defaultRoute + id);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ArticleDetailsDto>();
        }
    }
}
