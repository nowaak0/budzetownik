using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Budzetownik.Model;
using Budzetownik.Services;
using Microsoft.Maui.ApplicationModel; // Wibracje

namespace Budzetownik.ViewModels;

public class AddExpenseViewModel : INotifyPropertyChanged
{
    private readonly ApiService _apiService = new();

    public ObservableCollection<Category> Categories { get; set; } = new();
    public Category? SelectedCategory { get; set; }
    public string Description { get; set; } = "";
    public string Amount { get; set; } = "";
    public ImageSource? SelectedImage { get; set; }
    public FileResult? ImageFile { get; set; }


    public ICommand PickImageCommand => new Command(async () =>
    {
        var result = await FilePicker.PickAsync(new PickOptions
        {
            FileTypes = FilePickerFileType.Images
        });

        if (result != null)
        {
            ImageFile = result;
            SelectedImage = ImageSource.FromFile(result.FullPath);
            OnPropertyChanged(nameof(SelectedImage));
        }
    });

    public ICommand SaveCommand => new Command(async () =>
    {
        if (SelectedCategory == null) return;

        var expense = new Expense
        {
            Description = Description,
            Amount = decimal.Parse(Amount),
            CategoryId = SelectedCategory.Id,
        };

        var success = await _apiService.AddExpenseAsync(expense, ImageFile);


    
            await Shell.Current.DisplayAlert("Info", success ? "Dodano wydatek" : "Błąd", "OK");
        await Shell.Current.GoToAsync("..");
    });

    public async Task InitAsync()
    {
        var categories = await _apiService.GetCategoriesAsync();
        Categories.Clear();
        foreach (var category in categories)
            Categories.Add(category);
    }

    public AddExpenseViewModel()
    {
        _ = InitAsync();
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    void OnPropertyChanged(string prop) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}