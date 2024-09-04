using SQLite;

namespace BundledSQLiteDbExample.Models
{
    public class Employees
    {
        [AutoIncrement, PrimaryKey]
        public int Emp_ID { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
    }
}
