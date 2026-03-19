namespace ListomoraFront.Models.Enums
{
    public enum UnitTypeEnum
    {
        UNIT,     // unité
        PACK,     // paquet / pack
        CAN,      // conserve / canette
        BOX,      // boîte

        // Weight
        GRAM,        // gramme
        KILOGRAM,    // kilogramme
        MILLIGRAM,   // milligramme
        //OUNCE,       // once
        //POUND,       // livre

        // Volume
        MILLILITER,  // millilitre
        CENTILITER,  // centilitre
        LITER,       // litre
    }

    public static class UnitTypeHelper
    {
        public static string ToDescription(this UnitTypeEnum unit)
        {
            return unit switch
            {
                UnitTypeEnum.UNIT => "Unité",
                UnitTypeEnum.PACK => "Pack",
                UnitTypeEnum.CAN => "Conserve/Canette",
                UnitTypeEnum.BOX => "Boîte",

                UnitTypeEnum.GRAM => "Grammes",
                UnitTypeEnum.KILOGRAM => "Kilogrammes",
                UnitTypeEnum.MILLIGRAM => "Milligrammes",

                UnitTypeEnum.MILLILITER => "Millilitres",
                UnitTypeEnum.CENTILITER => "Centilitres",
                UnitTypeEnum.LITER => "Litres",

                _ => "Unité inconnue"
            };
        }
    }

    //public enum RecipeUnitTypeEnum
    //{
    //    // Weight
    //    GRAM,        // gramme
    //    KILOGRAM,    // kilogramme
    //    MILLIGRAM,   // milligramme
    //    OUNCE,       // once
    //    POUND,       // livre

    //    // Volume
    //    MILLILITER,  // millilitre
    //    CENTILITER,  // centilitre
    //    LITER,       // litre

    //    //// Cooking measures
    //    //TEASPOON,    // cuillère à café
    //    //TABLESPOON,  // cuillère à soupe
    //    //CUP,         // tasse

    //    //// Small quantities
    //    //PINCH,       // pincée
    //    //DASH         // petite quantité / trait
    //}

    //public enum ShoppingUnitTypeEnum
    //{
    //    UNIT,     // unité
    //    PACK,     // paquet / pack
    //    BAG,      // sac
    //    BOX,      // boîte
    //    BOTTLE,   // bouteille
    //    CAN,      // conserve / canette
    //    JAR,      // pot / bocal
    //    TUBE,     // tube

    //    // Weight
    //    GRAM,        // gramme
    //    KILOGRAM,    // kilogramme
    //    MILLIGRAM,   // milligramme
    //    OUNCE,       // once
    //    POUND,       // livre

    //    // Volume
    //    MILLILITER,  // millilitre
    //    CENTILITER,  // centilitre
    //    LITER,       // litre

    //    // Food specific
    //    PIECE     // pièce
    //}
}
