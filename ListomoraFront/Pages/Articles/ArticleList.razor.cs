using ListomoraFront.Models.Articles;
using ListomoraFront.Services.Implementations;
using Microsoft.AspNetCore.Components;

namespace ListomoraFront.Pages.Articles
{
    public partial class ArticleList
    {
        [Inject]
        private ArticleAPIClient _client { get; set; }
        [Inject]
        private NavigationManager _navigationManager { get; set; }
        public List<ArticleDto> Articles { get; set; } = new List<ArticleDto>();

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
