using System.ComponentModel.DataAnnotations;

namespace ListomoraFront.Models.Validators
{
    public class StrongPasswordAttribute : ValidationAttribute
    {
        public int MinimumLength { get; set; } = 8;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var password = value as string;

            if (string.IsNullOrWhiteSpace(password))
                return new ValidationResult("Le mot de passe est requis.");

            if (password.Length < MinimumLength)
                return new ValidationResult($"Le mot de passe doit contenir au moins {MinimumLength} caractères.");

            if (!password.Any(char.IsUpper))
                return new ValidationResult("Le mot de passe doit contenir au moins une majuscule.");

            if (!password.Any(char.IsLower))
                return new ValidationResult("Le mot de passe doit contenir au moins une minuscule.");

            if (!password.Any(char.IsDigit))
                return new ValidationResult("Le mot de passe doit contenir au moins un chiffre.");

            if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
                return new ValidationResult("Le mot de passe doit contenir au moins un caractère spécial.");

            return ValidationResult.Success;
        }
    }
}
