using Budzetownik.ViewModels;

namespace Budzetownik.Views;

public partial class ViewExpensesPage : ContentPage
{
	public ViewExpensesPage()
	{
		InitializeComponent();

        BindingContext = new ViewExpensesViewModel();
    }
    private async void GoHome_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
}