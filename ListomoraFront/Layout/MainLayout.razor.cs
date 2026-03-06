using ListomoraFront.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ListomoraFront.Layout
{
    public partial class MainLayout
    {
        private bool _isDarkMode = false;
        private MudTheme? _theme = null;
        [Inject]
        public ThemeService _themeService { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            _theme = new()
            {
                PaletteLight = _lightPalette,
                PaletteDark = _darkPalette,
                LayoutProperties = new LayoutProperties()
            };
            _isDarkMode = ThemeService.IsDarkMode;
            _themeService.OnThemeChanged += DarkModeToggle;
        }

        private async void DarkModeToggle()
        {
            _isDarkMode = ThemeService.IsDarkMode;
            await InvokeAsync(StateHasChanged);
        }

        private readonly PaletteLight _lightPalette = new()
        {
            Primary = "#8A6FF0",
            Secondary = "#1E1B2E",
            Tertiary = "#6B4FC9",
            Background = "#FAFAFE",
            TextPrimary = "#1E1B2E",
            TextSecondary = "#8A6FF0",
            //TextSecondary = "#3AD8C2",
            OverlayLight = "#1e1e2d80",
            DrawerIcon = "#1E1B2E",
            DrawerText = "#1E1B2E",
            DrawerBackground = "#8A6FF0",

            Dark = "#FAFAFE",

            //--primary: #8A6FF0;        /* Violet clair magique, lumineux et lisible */
            //--primary - dark: #6B4FC9;   /* Variante plus profonde pour hover ou accents */
            //--accent: #3AD8C2;         /* Vert d’eau brillant, contraste fort avec le violet */
            //--background: #FAFAFE;     /* Très clair, légèrement bleuté pour éviter le blanc pur */
            //--text: #1E1B2E; 

            Black = "#110e2d",
            AppbarText = "#424242",
            AppbarBackground = "rgba(255,255,255,0.8)",
            GrayLight = "#e8e8e8",
            GrayLighter = "#f9f9f9",
        };

        private readonly PaletteDark _darkPalette = new()
        {
            Primary = "#8A6FF0",
            Secondary = "#FAFAFE",
            Tertiary = "#6B4FC9",
            Background = "#1a1a27",
            TextPrimary = "#FAFAFE",
            TextSecondary = "#8A6FF0",
            //TextSecondary = "#3AD8C2",
            OverlayLight = "#1e1e2d80",
            DrawerIcon = "#FAFAFE",
            DrawerText = "#FAFAFE",
            DrawerBackground = "#1a1a27",

            Dark = "#FAFAFE",

            Surface = "#1e1e2d",
            BackgroundGray = "#151521",
            AppbarText = "#92929f",
            AppbarBackground = "rgba(26,26,39,0.8)",
            ActionDefault = "#74718e",
            ActionDisabled = "#9999994d",
            ActionDisabledBackground = "#605f6d4d",
            TextDisabled = "#ffffff33",
            GrayLight = "#2a2833",
            GrayLighter = "#1e1e2d",
            Info = "#4a86ff",
            Success = "#3dcb6c",
            Warning = "#ffb545",
            Error = "#ff3f5f",
            LinesDefault = "#33323e",
            TableLines = "#33323e",
            Divider = "#292838",
        };
    }
}
