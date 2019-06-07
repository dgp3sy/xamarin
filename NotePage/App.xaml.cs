using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NotePage.Services;
using NotePage.Views;

namespace NotePage
{
    public partial class App : Application
    {

        public App() // allows us to create application level behavior without the detail of either platform
        { // application initialization
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage(); // main page class set as the root page
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        static TodoItemDatabase database;

        public static TodoItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TodoItemDatabase(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return database;
            }
        }
    }
}
