using BundledSQLiteDbExample.Views;

namespace BundledSQLiteDbExample
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainDisplayPage), typeof(MainDisplayPage));

        }
    }
}
