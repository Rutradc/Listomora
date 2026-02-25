using ListomoraFront.Models.Articles;
using ListomoraFront.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace ListomoraFront.Pages.Articles
{
    public partial class ArticleDetails
    {
        [Parameter]
        public Guid Id { get; set; }
        [Inject]
        private IArticleService _client { get; set; }
        [Inject]
        private NavigationManager _navigationManager { get; set; }
        public ArticleDetailsDto Article { get; set; } = null;
        protected override async Task OnInitializedAsync()
        {
            Article = await _client.GetByIdAsync(Id);
        }
        public void GoToList()
        {
            _navigationManager.NavigateTo("/article");
        }
    }
}
