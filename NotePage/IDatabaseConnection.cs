using System;
using System.Collections.Generic;
using System.Text;

namespace NotePage
{
    public interface IDatabaseConnection
    {
        SQLite.SQLiteConnection DbConnection();
    }
}
