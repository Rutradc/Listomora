using ListomoraFront.Models.Articles;
using ListomoraFront.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace ListomoraFront.Pages.Articles
{
    public partial class ArticleList
    {
        [Inject]
        private IArticleService _client { get; set; }
        [Inject]
        private NavigationManager _navigationManager { get; set; }
        public List<ArticleListDto> Articles { get; set; } = new List<ArticleListDto>();

        protected override async Task OnInitializedAsync()
        {
            Articles = await _client.GetAllAsync();
        }
        public void GoToDetails(Guid id)
        {
            _navigationManager.NavigateTo("/article/" + id);
        }
    }
}
