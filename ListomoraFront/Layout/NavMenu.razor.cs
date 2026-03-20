using ListomoraFront.Models.Users;
using ListomoraFront.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace ListomoraFront.Layout
{
    public partial class NavMenu
    {
        [Inject]
        private NavigationManager _navigationManager { get; set; }
        private bool _expanded = true;

        private void OnExpandCollapseClick()
        {
            _expanded = !_expanded;
        }
        [Inject]
        private IAuthService _authService { get; set; }
        [Parameter]
        public UserNav User { get; set; }
        private bool IsConnected { 
            get
            {
                return User is not null;
            } 
        }

        private async Task Logout()
        {
            await _authService.LogoutAsync();
            _navigationManager.NavigateTo("/");
        }
    }
}
