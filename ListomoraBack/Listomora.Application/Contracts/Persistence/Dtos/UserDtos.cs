using Listomora.Domain.Enums;

namespace Listomora.Application.Contracts.Persistence.Dtos
{
    public class UserCreateDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Password { get; set; }
        public string CreationToken { get; set; }

        public UserCreateDto(string email, string firstName, string? lastName, string password, string creationToken)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            CreationToken = creationToken;
        }
    };
    public class UserUpdateDto
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
    }
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
    public class CreationTokenCreateDto
    {
        public string TokenHash { get; set; }
        public DateTime ExpiresAt { get; set; }
        public Guid AdminCreatorId { get; set; }

        public CreationTokenCreateDto(string tokenHash, DateTime expiresAt, Guid adminCreatorId)
        {
            TokenHash = tokenHash;
            ExpiresAt = expiresAt;
            AdminCreatorId = adminCreatorId;
        }
    }
}
