using ListomoraFront.CustomIcons;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.ComponentModel.DataAnnotations;

namespace ListomoraFront.Models.Ingredients
{
    public class IngredientCreateUpdateDto
    {
        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "Le nom doit contenir entre 1 et 150 caractères.")]
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public IngredientCategory Category { get; set; }
    };
    public class IngredientDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public IngredientCategory Category { get; set; }
        public string CreatorName { get; set; }
    }
    public class IngredientListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IngredientCategory Category { get; set; }
        public string CreatorName { get; set; }
    }
}
