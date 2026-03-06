using ListomoraFront.Models.Articles;
using ListomoraFront.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ListomoraFront.Pages.Articles
{
    public partial class ArticleAdminList
    {
        [Inject]
        private IArticleService _client { get; set; }
        [Inject]
        private NavigationManager _navigationManager { get; set; }
        [Inject]
        private ISnackbar _snackbar { get; set; }
        public List<ArticleDetailsDto> Articles { get; set; } = new List<ArticleDetailsDto>();
        private string searchString1 = "";
        private ArticleDetailsDto selectedArticle1 = null;
        private HashSet<ArticleDetailsDto> selectedArticles = new HashSet<ArticleDetailsDto>();

        private bool FilterFunc1(ArticleDetailsDto article) => FilterFunc(article, searchString1);

        private bool FilterFunc(ArticleDetailsDto article, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (article.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (article.CreatorName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        protected override async Task OnInitializedAsync()
        {
            Articles = await _client.GetAdminAllAsync();
        }
        public void GoToDetails(Guid id)
        {
            _navigationManager.NavigateTo("/article/details/adminlist/" + id);
        }
        public void GoToUpdate(Guid id)
        {
            _navigationManager.NavigateTo("/article/update/adminlist/" + id);
        }
        public async void Delete(Guid id)
        {
            bool isDeleted = await _client.DeleteAsync(id);
            if (isDeleted)
            {
                _snackbar.Add("Article supprimé", Severity.Success);
                var deleted = Articles.SingleOrDefault(x => x.Id == id);
                Articles.Remove(deleted);
                await InvokeAsync(StateHasChanged);
            }
            else
            {
                _snackbar.Add("L'article n'a pas pu être supprimé", Severity.Error);
            }
        }
        public async void GoToCreate()
        {
            _navigationManager.NavigateTo("/article/create/adminlist");
        }
    }
}
