using Isopoh.Cryptography.Argon2;
using Listomora.BLL.Services.Interfaces;
using Listomora.Domain.Model;
using Listomora.Domain.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Listomora.BLL.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepo _userRepo;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthService(IPasswordHasher<User> passwordHasher, IUserRepo userRepo)
        {
            _passwordHasher = passwordHasher;
            _userRepo = userRepo;
        }

        public async Task<bool> RegisterUser(User user)
        {
            if (user.FirstName is null || user.Email is null)
                return false;
            Argon2.Hash(user.Password);
            user.Password = _passwordHasher.HashPassword(user, user.Password);
            return await _userRepo.RegisterAsync(user);
        }

        public async Task<bool> VerifyLogin(string email, string providedPassword)
        {
            User user = await _userRepo.GetAsync(email);
            return Argon2.Verify(user.Password, providedPassword);
            //var result = _passwordHasher.VerifyHashedPassword(user, user.Password, providedPassword);
            //return result == PasswordVerificationResult.Success;
        }
    }
}
