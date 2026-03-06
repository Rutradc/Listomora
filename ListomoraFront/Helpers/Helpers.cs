namespace ListomoraFront.Helpers
{
    public static class InputAttributesHelper
    {
        public static Dictionary<string, object> NoAutoComplete = new()
        {
            { "autocomplete", "off" }
        };
        public static Dictionary<string, object> NewPassword = new()
        {
            { "autocomplete", "new-password" }
        };
    }
}
