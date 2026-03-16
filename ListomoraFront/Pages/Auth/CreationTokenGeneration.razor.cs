using ListomoraFront.Models.Auth;
using ListomoraFront.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ListomoraFront.Pages.Auth
{
    public partial class CreationTokenGeneration
    {
        [Inject]
        private IAuthService _service { get; set; }
        [Inject]
        private IJsApiService _jsApi { get; set; }
        [Inject]
        private ISnackbar _snackbar { get; set; }

        private CreationTokenCreateDto model = new CreationTokenCreateDto();
        private List<string> tokens = new List<string>();
        private bool isLoading = false;
        private string errorMessage;

        protected override async Task OnInitializedAsync()
        {
            model.ExpirationDate = DateTime.UtcNow.Date;
            model.ExpirationTime = DateTime.UtcNow.AddHours(1).TimeOfDay;
        }

        private async Task CopyToken(string token)
        {
            await _jsApi.CopyToClipboardAsync(token);
            _snackbar.Add("Token copié dans le presse-papiers!", Severity.Success);
        }

        private async Task HandleSubmit()
        {
            isLoading = true;
            errorMessage = null;

            try
            {
                var token = await _service.GenerateCreationTokenAsync(model);

                if (token is not null)
                {
                    tokens.Add(token);
                }
                else
                {
                    errorMessage = "Erreur dans la requête.";
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
    }
}
