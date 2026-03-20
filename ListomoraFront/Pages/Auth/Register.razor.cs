using ListomoraFront.Models.Auth;
using ListomoraFront.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ListomoraFront.Pages.Auth
{
    public partial class Register
    {
        [Inject]
        private IAuthService _service { get; set; }
        [Inject]
        private NavigationManager _navigation { get; set; }

        private CreationTokenModel tokenModel = new();
        private RegisterForm model = new ();
        private string errorMessage;
        private bool isLoading = false;
        private string creationToken;

        private bool hasValidToken = false;
        private bool isShown = false;
        private InputType PasswordInput = InputType.Password;
        private string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;

        private async Task CheckTokenValidity()
        {
            isLoading = true;
            errorMessage = null;
            if (await _service.CheckCreationTokenAsync(tokenModel.CreationToken))
            {
                hasValidToken = true;
                model.CreationToken = tokenModel.CreationToken;
            }
            else
            {
                errorMessage = "Token invalide.";
            }
            isLoading = false;
        }

        private async Task HandleRegister()
        {
            isLoading = true;
            errorMessage = null;

            try
            {
                bool success = await _service.RegisterAsync(model);

                if (success)
                {
                    _navigation.NavigateTo("/login");
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
                isLoading = false;
            }
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
        private class CreationTokenModel
        {
            public string CreationToken { get; set; }
        }
    }
}
