using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Listomora.API.Handlers
{
    public class CreationTokenService
    {
        private readonly IConfiguration _config;

        public CreationTokenService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateCreationToken()
        {
            byte[] bytes = RandomNumberGenerator.GetBytes(32);
            return Convert.ToHexString(bytes).ToLower();
        }

        public string HashToken(string token)
        {
            string secret = _config["SecretCreationToken"];
            var key = Encoding.UTF8.GetBytes(secret);

            using var hmac = new HMACSHA256(key);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(token));

            return Convert.ToHexString(hash).ToLower();
        }
    }
}
