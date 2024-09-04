using SQLite;
using BundledSQLiteDbExample.Models;
#if IOS
using CloudKit;
#endif

namespace BundledSQLiteDbExample.Data
{
    public class AppDatabase
    {
        public SQLiteAsyncConnection _database;
        public const string fileName = "EmpDatabase.db3";
        public static string DbPath { get; } = Path.Combine(FileSystem.Current.AppDataDirectory, fileName);
        public AppDatabase()
        {
            _database = new SQLiteAsyncConnection(DbPath);
            _database.CreateTableAsync<Employees>();
        }
        public async Task<List<Employees>> GetItemsAsync()
        {
            return await _database.Table<Employees>().ToListAsync();
        }
        public async Task<Employees> GetItemAsync(int emp_Id)
        {
            return await _database.Table<Employees>().Where(i => i.Emp_ID == emp_Id).FirstOrDefaultAsync();
        }
    }
}
