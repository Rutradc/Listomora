using ListomoraFront.Models.ShoppingLists;
using ListomoraFront.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace ListomoraFront.Pages.ShoppingLists
{
    public partial class MyShoppingLists
    {
        [Inject]
        private IShoppingListService _client { get; set; }
        [Inject]
        private NavigationManager _navigationManager { get; set; }
        public List<ShoppingListListDto> ShoppingLists { get; set; } = new List<ShoppingListListDto>();
        private string searchString1 = "";

        private bool FilterFunc1(ShoppingListListDto shoppinglist) => FilterFunc(shoppinglist, searchString1);

        private bool FilterFunc(ShoppingListListDto shoppinglist, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (shoppinglist.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        protected override async Task OnInitializedAsync()
        {
            ShoppingLists = await _client.GetMineAsync();
        }
        public void GoToDetails(Guid id)
        {
            _navigationManager.NavigateTo("/shoppinglist/page/mine/" + id);
        }
        public async void GoToCreate()
        {
            _navigationManager.NavigateTo("/shoppinglist/page/mine/");
        }
    }
}
