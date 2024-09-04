#nullable disable
using BundledSQLiteDbExample.Views;
using File = System.IO.File;

namespace BundledSQLiteDbExample
{
    public partial class MainPage : ContentPage
    {
        public const string fileName = "EmpDatabase.db3"; //Source Database File Name
        
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            CopyDb(fileName);
        }
        
        //to call asyn method synchronously
        public static void CopyDb(string fileName)
        {
            var task = CopyFileToAppDataDirectory(fileName);
            Func<System.Runtime.CompilerServices.TaskAwaiter> getAwaiter = task.GetAwaiter;
            Func<System.Runtime.CompilerServices.TaskAwaiter> result = getAwaiter; // Blocks until the task completes
        }

        //Copying method from Maui File System Helper
        public static async Task CopyFileToAppDataDirectory(string fileName)
        {
            // Open the source file
            using Stream inputStream = await FileSystem.Current.OpenAppPackageFileAsync(fileName);
            {
                //string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, fileName);
                string targetFile = Path.Combine(FileSystem.AppDataDirectory, fileName);

                // Copy the file to the AppDataDirectory
                using FileStream outputStream = File.Create(targetFile);
                await inputStream.CopyToAsync(outputStream);
            }
        }

        async void OnNavigation_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(MainDisplayPage));
        }
    }
}
