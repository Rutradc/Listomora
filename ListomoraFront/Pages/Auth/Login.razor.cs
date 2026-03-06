using ListomoraFront.Models.Auth;
using ListomoraFront.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ListomoraFront.Pages.Auth
{
    public partial class Login
    {
        [Inject]
        private IAuthService _service { get; set; }
        [Inject]
        private NavigationManager _navigation { get; set; }

        private LoginForm loginModel = new LoginForm();
        private bool isLoggingIn = false;
        private string errorMessage;

        private bool isShown = false;
        private InputType PasswordInput = InputType.Password;
        private string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
        //TODO: fix errorMessage qui se montre avec "Email ou mot de passe incorrect." avant de charger et de connecter l'utilisateur
        private async Task HandleLogin()
        {
            isLoggingIn = true;
            errorMessage = null;

            try
            {
                bool success = await _service.LoginAsync(loginModel);

                if (success)
                {
                    _navigation.NavigateTo("/");
                }
                else
                {
                    errorMessage = "Email ou mot de passe incorrect.";
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Impossible de contacter l'API. Vérifiez qu'elle est lancée.";
                Console.WriteLine(ex.Message);
            }
            finally
            {
                isLoggingIn = false;
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                // S'abonner à l'événement d'authentification
                _service.OnAuthStateChanged += HandleAuthStateChanged;
                // Initialiser l'état de l'utilisateur
                await RefreshUserStatus();
            }
        }

        // Méthode appelée lorsque l'état d'authentification change
        private async void HandleAuthStateChanged()
        {
            await RefreshUserStatus();
        }

        // Méthode pour rafraîchir l'état de l'utilisateur
        private async Task RefreshUserStatus()
        {
            await InvokeAsync(StateHasChanged);
        }

        private void ToggleShowPassword()
        {
            if (isShown)
            {
                isShown = false;
                PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
                PasswordInput = InputType.Password;
            }
            else
            {
                isShown = true;
                PasswordInputIcon = Icons.Material.Filled.Visibility;
                PasswordInput = InputType.Text;
            }
        }
    }
}
