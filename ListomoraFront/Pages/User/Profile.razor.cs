using ListomoraFront.Models.Users;
using ListomoraFront.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ListomoraFront.Pages.User
{
    public partial class Profile
    {
        private UserProfile User = new();
        private UserUpdateDto dto = new();
        [Inject]
        private IUserService _client { get; set; }
        [Inject]
        private IAuthService _authClient { get; set; }
        [Inject]
        private ISnackbar _snackbar { get; set; }
        private bool _isPageUpdate = false;
        private bool _isUpdating = false;
        protected override async Task OnInitializedAsync()
        {
            User = await _client.GetProfileAsync();
        }

        private async Task HandleUpdate()
        {
            _isUpdating = true;
            if (await _authClient.UpdateAsync(dto))
            {
                _snackbar.Add("Profil mis à jour!", Severity.Success);
                await ToggleUpdatePage();
            }
            else
                _snackbar.Add("Problème dans la mise à jour", Severity.Error);
        }
        private async Task ToggleUpdatePage()
        {
            if (!_isPageUpdate)
            {
                dto.FirstName = User.FirstName;
                dto.LastName = User.LastName;
                dto.Email = User.Email;
            }
            else
            {
                User = await _client.GetProfileAsync();
            }
            _isPageUpdate = !_isPageUpdate;
            //await InvokeAsync(StateHasChanged);
        }
    }
}
