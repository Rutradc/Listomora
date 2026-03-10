using ListomoraFront.Models.Ingredients;
using ListomoraFront.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ListomoraFront.Pages.Ingredients
{
    public partial class IngredientList
    {
        [Inject]
        private IIngredientService _client { get; set; }
        [Inject]
        private NavigationManager _navigationManager { get; set; }
        public List<IngredientListDto> Ingredients { get; set; } = new List<IngredientListDto>();
        private string searchString1 = "";
        private IngredientListDto selectedIngredient1 = null;
        private HashSet<IngredientListDto> selectedIngredients = new HashSet<IngredientListDto>();

        private bool FilterFunc1(IngredientListDto ingredient) => FilterFunc(ingredient, searchString1);

        private bool FilterFunc(IngredientListDto ingredient, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (ingredient.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (ingredient.CreatorName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (ingredient.Category.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        protected override async Task OnInitializedAsync()
        {
            Ingredients = await _client.GetAllAsync();
        }
        public void GoToDetails(Guid id)
        {
            _navigationManager.NavigateTo("/ingredient/details/list/" + id);
        }
        public async void GoToCreate()
        {
            _navigationManager.NavigateTo("/ingredient/create/list");
        }
    }
}
