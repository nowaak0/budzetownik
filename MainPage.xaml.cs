namespace Budzetownik
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            AnimateLogo();

            BtnDodajKategorie.Clicked += async (s, e) => await Shell.Current.GoToAsync("AddCategoryPage");
            BtnDodajWydatek.Clicked += async (s, e) => await Shell.Current.GoToAsync("AddExpensePage");
            BtnWyswietlWydatki.Clicked += async (s, e) => await Shell.Current.GoToAsync("ViewExpensesPage");
        }
        private async void AnimateLogo()
        {
            while (true)
            {
                await LogoImage.ScaleTo(1.1, 800, Easing.SinInOut);
                await LogoImage.ScaleTo(1.0, 800, Easing.SinInOut);
            }
        }

    }
}
