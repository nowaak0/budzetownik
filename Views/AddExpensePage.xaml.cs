using Budzetownik.ViewModels;

namespace Budzetownik.Views;

public partial class AddExpensePage : ContentPage
{
    public AddExpensePage()
    {
        InitializeComponent();

        BindingContext = new AddExpenseViewModel();
    }
    private async void GoHome_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
}