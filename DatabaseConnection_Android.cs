using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using NotePage.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_Android))]

namespace NotePage.Droid
{
    class DatabaseConnection_Android : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var path = "C:\\Users\\danny.perkins\\source\\repos\\NotePage\\NotePage\\NotePage.Android\\Assets\\my_table.db";
            return new SQLiteConnection(path);
        }
    }
}