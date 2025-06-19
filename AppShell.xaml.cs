namespace Budzetownik
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("AddCategoryPage", typeof(Views.AddCategoryPage));
            Routing.RegisterRoute("AddExpensePage", typeof(Views.AddExpensePage));
            Routing.RegisterRoute("ViewExpensesPage", typeof(Views.ViewExpensesPage));

            // Załaduj motyw przy starcie aplikacji
            LoadTheme();
        }

        private void ThemeSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            SetTheme(e.Value);
        }

        void SetTheme(bool isDark)
        {
            if (Application.Current != null)
            {
                // Ustaw motyw aplikacji
                Application.Current.UserAppTheme = isDark ? AppTheme.Dark : AppTheme.Light;

                // Zapisz preferencję użytkownika
                Preferences.Set("IsDarkTheme", isDark);
            }
        }

        void LoadTheme()
        {
            // Odczytaj zapisaną preferencję (domyślnie motyw jasny)
            var isDark = Preferences.Get("IsDarkTheme", false);

            // Ustaw stan przełącznika bez wywoływania zdarzenia Toggled
            ThemeSwitch.Toggled -= ThemeSwitch_Toggled;
            ThemeSwitch.IsToggled = isDark;
            ThemeSwitch.Toggled += ThemeSwitch_Toggled;

            // Zastosuj wczytany motyw
            SetTheme(isDark);
        }
    }
}