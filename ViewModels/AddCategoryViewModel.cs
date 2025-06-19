using System.ComponentModel;
using System.Windows.Input;
using Budzetownik.Model;
using Budzetownik.Services;

namespace Budzetownik.ViewModels
{
    public class AddCategoryViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService = new();

        public string CategoryName { get; set; } = "";

        public ICommand SaveCommand => new Command(async () =>
        {
            if (!string.IsNullOrWhiteSpace(CategoryName))
            {
                var result = await _apiService.AddCategoryAsync(new Category { Name = CategoryName });
                await Shell.Current.DisplayAlert("Info", result ? "Dodano!" : "Błąd", "OK");
                await Shell.Current.GoToAsync("..");
            }
        });

        public event PropertyChangedEventHandler? PropertyChanged;
    }

}
