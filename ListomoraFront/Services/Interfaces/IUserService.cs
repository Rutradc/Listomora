using ListomoraFront.Models.Users;

namespace ListomoraFront.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserProfile> GetProfileAsync();
        Task<UserNav> GetNavAsync();
    }
}
