using FizzBuzzWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;


namespace FizzBuzzWebApp.Pages
{
    public class FizzBuzzDisplayModel : PageModel
    {
        public List<String> tableEntries = new List<String>();
        public void OnGet()
        {
            try
            {
                // database connection created and SQL statement executed to retrieve data. Data is displayed with Razor Pages.
                using (var connection = new SqliteConnection("Data Source=FizzBuzzWebAppDatabase.sqlite"))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"SELECT * FROM TableRows";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            String rowEntry = reader.GetString(1);
                            tableEntries.Add(rowEntry);
                        }
                    }
                    connection.Close();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
            catch
            {
                Console.WriteLine("Unable to create connection to database");
            }
        }
    }
}
