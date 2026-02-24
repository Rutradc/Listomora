using ListomoraFront.Models.Users;
using ListomoraFront.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace ListomoraFront.Layout
{
    public partial class NavMenu : IDisposable
    {
        [Inject]
        private IAuthService _authService { get; set; }
        [Inject]
        private IUserService _userService { get; set; }
        private UserNav User { get; set; }
        private bool IsConnected { 
            get
            {
                return User is not null;
            } 
        }

        protected override async Task OnInitializedAsync()
        {
            // S'abonner à l'événement d'authentification
            _authService.OnAuthStateChanged += HandleAuthStateChanged;
            // Charger l'état initial
            await RefreshUserStatus();
        }

        private async Task Logout()
        {
            _authService.LogoutAsync();
        }

        private async void HandleAuthStateChanged()
        {
            await RefreshUserStatus();
        }

        private async Task RefreshUserStatus()
        {
            User = await _userService.GetNavAsync();
            await InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            // Se désabonner de l'événement d'authentification pour éviter les fuites de mémoire
            _authService.OnAuthStateChanged -= HandleAuthStateChanged;
        }
    }
}
