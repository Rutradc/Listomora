using ListomoraFront.Models.ShoppingLists;
using ListomoraFront.Services.Interfaces;
using System.Net.Http.Json;

namespace ListomoraFront.Services.Implementations
{
    public class ShoppingListAPIClient : IShoppingListService
    {
        private readonly HttpClient _http;
        private readonly string _defaultRoute = "/api/ShoppingList/";

        public ShoppingListAPIClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> Complete(Guid id)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync(_defaultRoute + "complete", id);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            HttpResponseMessage response = await _http.DeleteAsync(_defaultRoute + id);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<ShoppingListListDto>> GetAllAsync()
        {
            HttpResponseMessage response = await _http.GetAsync(_defaultRoute + "list");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<ShoppingListListDto>>();
        }

        public async Task<ShoppingListDetailsDto> GetByIdAsync(Guid id)
        {
            HttpResponseMessage response = await _http.GetAsync(_defaultRoute + id);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ShoppingListDetailsDto>();
        }

        public async Task<List<ShoppingListListDto>> GetMineAsync()
        {
            HttpResponseMessage response = await _http.GetAsync(_defaultRoute + "mine");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<ShoppingListListDto>>();
        }

        public async Task<Guid> InsertAsync(ShoppingListCreateDto form)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync(_defaultRoute, form);
            return await response.Content.ReadFromJsonAsync<Guid>();
        }

        public async Task<bool> UpdateAsync(Guid id, ShoppingListUpdateDto form)
        {
            HttpResponseMessage response = await _http.PatchAsJsonAsync(_defaultRoute + id, form);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateLinesAsync(IEnumerable<ShoppingListLineCreateUpdateDto> dtos)
        {
            HttpResponseMessage response = await _http.PatchAsJsonAsync(_defaultRoute + "lines", dtos);
            return response.IsSuccessStatusCode;
        }
    }
}
