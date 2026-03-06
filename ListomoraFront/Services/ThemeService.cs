namespace ListomoraFront.Services
{
    public class ThemeService
    {
        public event Action? OnThemeChanged;
        public static bool IsDarkMode = false;
        public void ToggleTheme()
        {
            IsDarkMode = !IsDarkMode;
            OnThemeChanged?.Invoke();
        }
    }
}
