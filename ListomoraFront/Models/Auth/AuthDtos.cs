using ListomoraFront.Models.Validators;
using System.ComponentModel.DataAnnotations;

namespace ListomoraFront.Models.Auth
{
    public class LoginForm
    {
        [Required(ErrorMessage = "Veuillez renseigner votre email.")]
        [EmailAddress(ErrorMessage = "L'adresse e-mail fournie n'est pas valide.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Veuillez donner le mot de passe.")]
        public string Password { get; set; }

    }

    public class RegisterForm
    {
        [Required(ErrorMessage = "Le prénom est obligatoire.")]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "Le prénom doit contenir entre 1 et 150 caractères.")]
        public string FirstName { get; set; }
        [StringLength(150, ErrorMessage = "Le nom de famille ne doit pas dépasser 150 caractères.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "L'adresse e-mail est obligatoire.")]
        [EmailAddress(ErrorMessage = "L'adresse e-mail fournie n'est pas valide.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        [StrongPassword(MinimumLength = 8)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Veuillez confirmer le mot de passe.")]
        [Compare(nameof(Password), ErrorMessage = "Les mots de passe ne correspondent pas.")]
        public string PasswordConfirmation { get; set; }
    }
}
