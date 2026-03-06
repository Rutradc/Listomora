using ListomoraFront.Models.Articles;
using ListomoraFront.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ListomoraFront.Pages.Articles
{
    public partial class ArticleList
    {
        [Inject]
        private IArticleService _client { get; set; }
        [Inject]
        private NavigationManager _navigationManager { get; set; }
        [Inject]
        private ISnackbar _snackbar { get; set; }
        public List<ArticleListDto> Articles { get; set; } = new List<ArticleListDto>();
        private string searchString1 = "";
        private ArticleListDto selectedArticle1 = null;
        private HashSet<ArticleListDto> selectedArticles = new HashSet<ArticleListDto>();

        private bool FilterFunc1(ArticleListDto article) => FilterFunc(article, searchString1);

        private bool FilterFunc(ArticleListDto article, string searchString)
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
            Articles = await _client.GetAllAsync();
        }
        public void GoToDetails(Guid id)
        {
            _navigationManager.NavigateTo("/article/details/list/" + id);
        }
        public async void GoToCreate()
        {
            _navigationManager.NavigateTo("/article/create/list");
        }
    }
}
