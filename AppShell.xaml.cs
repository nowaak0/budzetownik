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
        }
    }
}
