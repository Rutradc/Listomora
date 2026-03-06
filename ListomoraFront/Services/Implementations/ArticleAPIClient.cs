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

        public async Task<List<ArticleDetailsDto>> GetMineAsync()
        {
            HttpResponseMessage response = await _http.GetAsync(_defaultRoute + "mine");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<ArticleDetailsDto>>();
        }

        public async Task<List<ArticleDetailsDto>> GetAdminAllAsync()
        {
            HttpResponseMessage response = await _http.GetAsync(_defaultRoute + "list");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<ArticleDetailsDto>>();
        }

        public async Task<ArticleDetailsDto> GetByIdAsync(Guid id)
        {
            HttpResponseMessage response = await _http.GetAsync(_defaultRoute + id);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ArticleDetailsDto>();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            HttpResponseMessage response = await _http.DeleteAsync(_defaultRoute + id);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> InsertAsync(ArticleCreateUpdateDto form)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync(_defaultRoute, form);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Guid id, ArticleCreateUpdateDto form)
        {
            HttpResponseMessage response = await _http.PatchAsJsonAsync(_defaultRoute + id, form);
            return response.IsSuccessStatusCode;
        }
    }
}
