using ListomoraFront.Models.Ingredients;
using ListomoraFront.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace ListomoraFront.Pages.Ingredients
{
    public partial class IngredientDetails
    {
        [Parameter]
        public Guid Id { get; set; }
        [Parameter]
        public string SourceUrl { get; set; }
        [Inject]
        private IIngredientService _client { get; set; }
        [Inject]
        private NavigationManager _navigationManager { get; set; }
        public IngredientDetailsDto Ingredient { get; set; } = null;
        protected override async Task OnInitializedAsync()
        {
            Ingredient = await _client.GetByIdAsync(Id);
            switch (SourceUrl)
            {
                case "list":
                case "adminlist":
                case "mine":
                    break;
                default:
                    SourceUrl = "list";
                    await InvokeAsync(StateHasChanged);
                    break;
            }
        }
        public void GoToList()
        {
            _navigationManager.NavigateTo("/ingredient/" + SourceUrl);
        }
    }
}
