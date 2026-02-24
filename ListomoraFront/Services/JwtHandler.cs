using Blazored.LocalStorage;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;

namespace ListomoraFront.Services
{
    public class JwtHandler : DelegatingHandler
    {
        private readonly ILocalStorageService _localStorage;

        public JwtHandler(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Console.WriteLine("JWT HANDLER EXECUTÉ");
            var token = await _localStorage.GetItemAsync<string>("token");

            if (!string.IsNullOrEmpty(token))
            {
                token = token.Trim('"');

                if (IsTokenExpired(token))
                {
                    await _localStorage.RemoveItemAsync("token");
                }
                else
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
            }

            // On laisse la requête partir vers l'API
            return await base.SendAsync(request, cancellationToken);
        }

        private bool IsTokenExpired(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                // Vérifier si le token n'est pas expiré
                return jwtToken.ValidTo <= DateTime.UtcNow;
            }
            catch
            {
                // Si on ne peut pas lire le token, on considère qu'il est expiré
                return true;
            }
        }
    }
}