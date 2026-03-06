using System.ComponentModel.DataAnnotations;

namespace ListomoraFront.Models.Users
{
    public class UserProfile
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
    }

    public class UserNav
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public UserRole? Role { get; set; }

        public UserNav(string firstName, string? lastName, UserRole? role = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Role = role;
        }
    }

    public class UserUpdateDto
    {
        [Required(ErrorMessage = "Le prénom est obligatoire.")]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "Le prénom doit contenir entre 1 et 150 caractères.")]
        public string FirstName { get; set; }
        [StringLength(150, ErrorMessage = "Le nom de famille ne doit pas dépasser 150 caractères.")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "L'adresse e-mail est obligatoire.")]
        [EmailAddress(ErrorMessage = "L'adresse e-mail fournie n'est pas valide.")]
        public string Email { get; set; }
    }

    public enum UserRole
    {
        ADMIN,  // 0
        USER    // 1
    }
}
