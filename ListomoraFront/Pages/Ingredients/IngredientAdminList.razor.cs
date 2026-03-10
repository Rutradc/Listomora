using ListomoraFront.Models.Ingredients;
using ListomoraFront.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ListomoraFront.Pages.Ingredients
{
    public partial class IngredientAdminList
    {
        [Inject]
        private IIngredientService _client { get; set; }
        [Inject]
        private NavigationManager _navigationManager { get; set; }
        [Inject]
        private ISnackbar _snackbar { get; set; }
        public List<IngredientDetailsDto> Ingredients { get; set; } = new List<IngredientDetailsDto>();
        private string searchString1 = "";
        private IngredientDetailsDto selectedIngredient1 = null;
        private HashSet<IngredientDetailsDto> selectedIngredients = new HashSet<IngredientDetailsDto>();

        private bool FilterFunc1(IngredientDetailsDto ingredient) => FilterFunc(ingredient, searchString1);

        private bool FilterFunc(IngredientDetailsDto ingredient, string searchString)
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
            Ingredients = await _client.GetAdminAllAsync();
        }
        public void GoToDetails(Guid id)
        {
            _navigationManager.NavigateTo("/ingredient/details/adminlist/" + id);
        }
        public void GoToUpdate(Guid id)
        {
            _navigationManager.NavigateTo("/ingredient/update/adminlist/" + id);
        }
        public async void Delete(Guid id)
        {
            bool isDeleted = await _client.DeleteAsync(id);
            if (isDeleted)
            {
                _snackbar.Add("Ingrédient supprimé", Severity.Success);
                var deleted = Ingredients.SingleOrDefault(x => x.Id == id);
                Ingredients.Remove(deleted);
                await InvokeAsync(StateHasChanged);
            }
            else
            {
                _snackbar.Add("L'ingrédient n'a pas pu être supprimé", Severity.Error);
            }
        }
        public async void GoToCreate()
        {
            _navigationManager.NavigateTo("/ingredient/create/adminlist");
        }
    }
}
