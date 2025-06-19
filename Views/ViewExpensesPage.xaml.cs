using Budzetownik.ViewModels;

namespace Budzetownik.Views;

public partial class ViewExpensesPage : ContentPage
{
	public ViewExpensesPage()
	{
        InitializeComponent();
    }
    private async void GoHome_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
}