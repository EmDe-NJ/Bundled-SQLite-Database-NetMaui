#nullable disable
using System.Collections.ObjectModel;
using BundledSQLiteDbExample.Data;
using BundledSQLiteDbExample.Models;
using File = System.IO.File;

namespace BundledSQLiteDbExample.Views;

public partial class MainDisplayPage : ContentPage
{
    AppDatabase _database;
    public ObservableCollection<Employees> Emp_List { get; set; } = [];
    public MainDisplayPage()
	{
        _database = new AppDatabase();
        InitializeComponent();
        BindingContext = this;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        {
            var employees = await _database.GetItemsAsync();
            Emp_List.Clear();
            foreach (var employee in employees)
            {
                Emp_List.Add(employee);
            }
            listView.ItemsSource = Emp_List;
        }
    }
}