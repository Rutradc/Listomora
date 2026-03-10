using ListomoraFront.CustomIcons;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ListomoraFront.Models.Ingredients
{
    public enum IngredientCategory
    {
        VEGETABLES, // légumes
        FRUITS, // fruits
        CEREALS, // céréales
        LEGUMES, // légumineuses
        MEAT, // viande
        FISH_AND_SEAFOODS, // poisson et fruits de mer
        EGGS, // oeufs
        DAIRY_PRODUCTS, // produits laitiers
        FATS, // matières grasses
        CONDIMENTS, // condiments
        HERBS_AND_SPICES, // herbes et épices
        SWEET_PRODUCTS, // produits sucrés
        BAKED_AND_PASTRIES, // produits de pâtisserie
        PREPARED_FOODS, // produits préparés
        BEVERAGES // boissons
    }

    public static class CategoryHelper
    {
        public static string ToDescription(this IngredientCategory category)
        {
            switch (category)
            {
                case IngredientCategory.VEGETABLES:
                    return "Légumes";
                case IngredientCategory.FRUITS:
                    return "Fruits";
                case IngredientCategory.CEREALS:
                    return "Céréales";
                case IngredientCategory.LEGUMES:
                    return "Légumineuses";
                case IngredientCategory.MEAT:
                    return "Viande";
                case IngredientCategory.FISH_AND_SEAFOODS:
                    return "Poisson et fruits de mer";
                case IngredientCategory.EGGS:
                    return "Œufs";
                case IngredientCategory.DAIRY_PRODUCTS:
                    return "Produits laitiers";
                case IngredientCategory.FATS:
                    return "Matières grasses";
                case IngredientCategory.CONDIMENTS:
                    return "Condiments";
                case IngredientCategory.HERBS_AND_SPICES:
                    return "Herbes et épices";
                case IngredientCategory.SWEET_PRODUCTS:
                    return "Produits sucrés";
                case IngredientCategory.BAKED_AND_PASTRIES:
                    return "Pâtisseries";
                case IngredientCategory.PREPARED_FOODS:
                    return "Produits préparés";
                case IngredientCategory.BEVERAGES:
                    return "Boissons";
                default:
                    return "Non valide";
            }
        }

        private static RenderFragment CreateIcon(string? icon = null, string? viewbox = null, bool isCustomIcon = false) => builder =>
        {
            builder.OpenComponent<MudIcon>(0);
            if (icon is not null)
                builder.AddAttribute(1, "Icon", icon);
            if (viewbox is not null)
                builder.AddAttribute(2, "ViewBox", viewbox);
            if (isCustomIcon)
                builder.AddAttribute(3, "Style", "vertical-align: middle;");

            builder.CloseComponent();
        };

        public static RenderFragment ToIconFragment(this IngredientCategory category)
        {
            switch (category)
            {
                case IngredientCategory.VEGETABLES:
                    return CreateIcon("fas fa-carrot");
                case IngredientCategory.FRUITS:
                    return CreateIcon("fas fa-apple-whole");
                case IngredientCategory.CEREALS:
                    return CreateIcon("fas fa-wheat-awn");
                case IngredientCategory.LEGUMES:
                    return CreateIcon(CustomSvgs.BeanIcon, "0 0 559 577", true);
                case IngredientCategory.MEAT:
                    return CreateIcon("fas fa-drumstick-bite");
                case IngredientCategory.FISH_AND_SEAFOODS:
                    return CreateIcon("fas fa-shrimp");
                case IngredientCategory.EGGS:
                    return CreateIcon("fas fa-egg");
                case IngredientCategory.DAIRY_PRODUCTS:
                    return CreateIcon("fas fa-cheese");
                case IngredientCategory.FATS:
                    return CreateIcon("fas fa-bottle-droplet");
                case IngredientCategory.CONDIMENTS:
                    return CreateIcon(CustomSvgs.SaltIcon, "0 0 356 575", true);
                case IngredientCategory.HERBS_AND_SPICES:
                    return CreateIcon("fas fa-mortar-pestle");
                case IngredientCategory.SWEET_PRODUCTS:
                    return CreateIcon("fas fa-cookie");
                case IngredientCategory.BAKED_AND_PASTRIES:
                    return CreateIcon(Icons.Material.Filled.BakeryDining, "0 0 24 24");
                case IngredientCategory.PREPARED_FOODS:
                    return CreateIcon(Icons.Material.Filled.Microwave, "0 0 24 24");
                case IngredientCategory.BEVERAGES:
                    return CreateIcon("fas fa-wine-bottle");
                default:
                    return CreateIcon("fas fa-notdef");
            }
        }
    }
}
