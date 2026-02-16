using ListomoraFront.Models.Validators;
using System.ComponentModel.DataAnnotations;

namespace ListomoraFront.Models.Auth
{
    public class LoginForm
    {
        [Required]
        [EmailAddress(ErrorMessage = "L'adresse e-mail fournie n'est pas valide.")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }

    public class RegisterForm
    {
        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "Le prénom doit contenir entre 1 et 150 caractères.")]
        public string FirstName { get; set; }
        [StringLength(150, ErrorMessage = "Le nom de famille ne doit pas dépasser 150 caractères.")]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "L'adresse e-mail fournie n'est pas valide.")]
        public string Email { get; set; }

        [Required]
        [StrongPassword(MinimumLength = 8)]
        public string Password { get; set; }
    }
}
