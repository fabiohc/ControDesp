using App1.Droid.Implementations;
using App1.Interfaces;
using SQLite;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteConnection_Droid))]
namespace App1.Droid.Implementations
{
    public class SQLiteConnection_Droid : ISQLiteConnection
    {
        public SQLiteConnection DBConnection()
        {
            var path = Path.Combine(System.Environment.
                                    GetFolderPath(System.Environment.
                                    SpecialFolder.Personal), "despesas.db3");
            return new SQLiteConnection(path);
        }
    }
}