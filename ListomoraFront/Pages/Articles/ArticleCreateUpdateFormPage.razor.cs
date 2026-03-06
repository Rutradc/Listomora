using ListomoraFront.Models.Articles;
using ListomoraFront.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ListomoraFront.Pages.Articles
{
    public partial class ArticleCreateUpdateFormPage
    {
        [Inject]
        private ISnackbar _snackbar { get; set; }
        [Inject]
        private NavigationManager _navigationManager { get; set; }
        [Inject]
        private IArticleService _client { get; set; }
        [Parameter] // si id non null alors update sinon create
        public Guid? Id { get; set; } = null;
        [Parameter]
        public string SourceUrl { get; set; }
        private ArticleCreateUpdateDto dto { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            if (Id is not null)
            {
                var article = await _client.GetByIdAsync((Guid)Id);
                dto.Name = article.Name;
                dto.IsPublic = article.IsPublic;
            }
        }

        private async Task Submit()
        {
            if (Id is null)
            {
                if (await _client.InsertAsync(dto))
                {
                    _snackbar.Add("Article ajouté!", Severity.Success);
                    _navigationManager.NavigateTo("/article/" + SourceUrl);
                }
                else
                    _snackbar.Add("Problème dans l'ajout", Severity.Error);
            }
            else
            {
                if (await _client.UpdateAsync((Guid)Id, dto))
                {
                    _snackbar.Add("Article mis à jour!", Severity.Success);
                    _navigationManager.NavigateTo("/article/" + SourceUrl);
                }
                else
                    _snackbar.Add("Problème dans la mise à jour", Severity.Error);
            }
        }
    }
}
