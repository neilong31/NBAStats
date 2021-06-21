using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DPS926_A2.Droid;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]
namespace DPS926_A2.Droid
{
    public class SQLiteDb : ISOLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "NBASQLite.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}