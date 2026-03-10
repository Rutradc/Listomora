using Microsoft.AspNetCore.Components;

namespace ListomoraFront.Pages.Ingredients
{
    public partial class IngredientUpdate
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
                case "adminlist":
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
