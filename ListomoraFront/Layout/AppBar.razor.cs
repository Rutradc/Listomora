using ListomoraFront.Models.Users;
using ListomoraFront.Services;
using ListomoraFront.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ListomoraFront.Layout
{
    public partial class AppBar : IDisposable
    {
        [Inject]
        private ThemeService _themeService { get; set; }
        private bool _drawerOpen = true;
        private bool _isDarkMode = false;
        private UserNav User;
        [Inject]
        private IAuthService _authService { get; set; }
        [Inject]
        private IUserService _userService { get; set; }
        [Inject]
        private NavigationManager _navigation { get; set; }
        private bool IsConnected
        {
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

        private async void HandleAuthStateChanged()
        {
            await RefreshUserStatus();
        }

        private async Task RefreshUserStatus()
        {
            User = await _userService.GetNavAsync();
            var currentPath = _navigation.ToBaseRelativePath(_navigation.Uri);
            if (User is not null && (currentPath == "login" || currentPath == "register"))
                _navigation.NavigateTo("/");
            await InvokeAsync(StateHasChanged);
        }

        private void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }

        private void DarkModeToggle()
        {
            _themeService.ToggleTheme();
            _isDarkMode = !_isDarkMode;
        }

        public string DarkLightModeButtonIcon => _isDarkMode switch
        {
            true => Icons.Material.Rounded.LightMode,
            false => Icons.Material.Rounded.DarkMode,
        };

        public void Dispose()
        {
            // Se désabonner de l'événement d'authentification pour éviter les fuites de mémoire
            _authService.OnAuthStateChanged -= HandleAuthStateChanged;
        }
    }
}
