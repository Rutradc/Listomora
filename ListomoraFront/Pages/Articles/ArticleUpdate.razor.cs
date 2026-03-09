using Microsoft.AspNetCore.Components;

namespace ListomoraFront.Pages.Articles
{
    public partial class ArticleUpdate
    {
        [Parameter]
        public Guid Id { get; set; }
        [Parameter]
        public string SourceUrl { get; set; }
        protected override async Task OnInitializedAsync()
        {
            switch (SourceUrl)
            {
                case "list":
                case "adminList":
                case "mine":
                    break;
                default:
                    SourceUrl = "list";
                    await InvokeAsync(StateHasChanged);
                    break;
            }
        }
    }
}
