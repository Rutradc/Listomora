using Listomora.Domain.Enums;

namespace Listomora.Application.Contracts.Persistence.Dtos
{
    public class UserCreateDto
    {
        // TODO : ajouter token de création de compte
        // string CreationToken,
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Password { get; set; }

        public UserCreateDto(string email, string firstName, string? lastName, string password)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }
    };
    public class UserCredsDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public UserCredsDto(string email, string password)
        {
            Email = email;
            Password = password;
        }
    };
    public class UserForToken
    {
        public Guid UserId { get; set; }
        public UserRole Role { get; set; }

        public UserForToken(Guid userId, UserRole role)
        {
            UserId = userId;
            Role = role;
        }
    }
    public class UserProfileDto
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }

        public UserProfileDto(string firstName, string? lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
    public class UserNavDto
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public UserRole? Role { get; set; }

        public UserNavDto(string firstName, string? lastName, UserRole? role = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Role = role;
        }
    }
}
