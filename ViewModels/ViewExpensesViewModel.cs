using System.Collections.ObjectModel;
using Budzetownik.Model;
using Budzetownik.Services;

namespace Budzetownik.ViewModels
{
    public class ViewExpensesViewModel
    {
        public ObservableCollection<CategoryGroup> GroupedExpenses { get; set; } = new();
        private readonly ApiService _apiService = new();

        public async Task LoadAsync()
        {
            var categories = await _apiService.GetCategoriesAsync();
            GroupedExpenses.Clear();

            foreach (var category in categories)
            {
                var expenses = category.Expenses ?? new List<Expense>();

                var group = new CategoryGroup(category.Name, expenses);
                GroupedExpenses.Add(group);
            }
        }

        public ViewExpensesViewModel()
        {
            _ = LoadAsync();
        }
    }

    public class CategoryGroup : ObservableCollection<Expense>
    {
        public string Name { get; }

        public CategoryGroup(string name, IEnumerable<Expense> expenses) : base(expenses)
        {
            Name = name;
        }
    }


}
