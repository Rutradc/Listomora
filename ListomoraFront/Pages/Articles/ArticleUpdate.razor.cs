using Microsoft.AspNetCore.Components;

namespace ListomoraFront.Pages.Articles
{
    public partial class ArticleUpdate
    {
        [Parameter]
        public Guid Id { get; set; }
        [Parameter]
        public string SourceUrl { get; set; }
    }
}
