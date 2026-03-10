using ListomoraFront.Models.Ingredients;
using ListomoraFront.Services.Interfaces;
using System.Net.Http.Json;

namespace ListomoraFront.Services.Implementations
{
    public class IngredientAPIClient : IIngredientService
    {
        private readonly HttpClient _http;
        private readonly string _defaultRoute = "/api/Ingredient/";

        public IngredientAPIClient(HttpClient http, IConfiguration config)
        {
            _http = http;
        }

        public async Task<List<IngredientListDto>> GetAllAsync()
        {
            HttpResponseMessage response = await _http.GetAsync(_defaultRoute);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<IngredientListDto>>();
        }

        public async Task<List<IngredientDetailsDto>> GetMineAsync()
        {
            HttpResponseMessage response = await _http.GetAsync(_defaultRoute + "mine");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<IngredientDetailsDto>>();
        }

        public async Task<List<IngredientDetailsDto>> GetAdminAllAsync()
        {
            HttpResponseMessage response = await _http.GetAsync(_defaultRoute + "list");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<IngredientDetailsDto>>();
        }

        public async Task<IngredientDetailsDto> GetByIdAsync(Guid id)
        {
            HttpResponseMessage response = await _http.GetAsync(_defaultRoute + id);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IngredientDetailsDto>();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            HttpResponseMessage response = await _http.DeleteAsync(_defaultRoute + id);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> InsertAsync(IngredientCreateUpdateDto form)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync(_defaultRoute, form);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Guid id, IngredientCreateUpdateDto form)
        {
            HttpResponseMessage response = await _http.PatchAsJsonAsync(_defaultRoute + id, form);
            return response.IsSuccessStatusCode;
        }
    }
}
