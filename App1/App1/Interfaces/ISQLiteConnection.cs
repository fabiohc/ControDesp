using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Interfaces
{
   public interface ISQLiteConnection
    {
        SQLiteConnection DBConnection();
    }
}
