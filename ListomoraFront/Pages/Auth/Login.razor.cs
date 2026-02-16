using ListomoraFront.Models.Auth;
using ListomoraFront.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace ListomoraFront.Pages.Auth
{
    public partial class Login
    {
        [Inject]
        private IAuthService _service { get; set; }
        [Inject]
        private NavigationManager _navigation { get; set; }

        private LoginForm loginModel = new LoginForm();
        private string errorMessage;
        private bool isLoggingIn = false;

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
    }
}
