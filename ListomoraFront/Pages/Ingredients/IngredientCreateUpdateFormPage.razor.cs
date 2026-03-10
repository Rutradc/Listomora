using ListomoraFront.Models.Ingredients;
using ListomoraFront.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ListomoraFront.Pages.Ingredients
{
    public partial class IngredientCreateUpdateFormPage
    {
        [Inject]
        private ISnackbar _snackbar { get; set; }
        [Inject]
        private NavigationManager _navigationManager { get; set; }
        [Inject]
        private IIngredientService _client { get; set; }
        [Parameter] // si id non null alors update sinon create
        public Guid? Id { get; set; } = null;
        [Parameter]
        public string SourceUrl { get; set; }
        private IngredientCreateUpdateDto dto { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            if (Id is not null)
            {
                var ingredient = await _client.GetByIdAsync((Guid)Id);
                dto.Name = ingredient.Name;
                dto.IsPublic = ingredient.IsPublic;
                dto.Category = ingredient.Category;
            }
        }

        private async Task Submit()
        {
            if (Id is null)
            {
                if (await _client.InsertAsync(dto))
                {
                    _snackbar.Add("Ingredient ajouté!", Severity.Success);
                    _navigationManager.NavigateTo("/ingredient/" + SourceUrl);
                }
                else
                    _snackbar.Add("Problème dans l'ajout", Severity.Error);
            }
            else
            {
                if (await _client.UpdateAsync((Guid)Id, dto))
                {
                    _snackbar.Add("Ingredient mis à jour!", Severity.Success);
                    _navigationManager.NavigateTo("/ingredient/" + SourceUrl);
                }
                else
                    _snackbar.Add("Problème dans la mise à jour", Severity.Error);
            }
        }
    }
}
