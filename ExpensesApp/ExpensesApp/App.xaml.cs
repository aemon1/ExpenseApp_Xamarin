using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ExpensesApp.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Analytics;

namespace ExpensesApp
{
    public partial class App : Application
    {
        public static string DatabasePath;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string databasePath)
        {
            InitializeComponent();
            DatabasePath = databasePath;
            MainPage = new NavigationPage(new MainPage());
        }

        protected override async void OnStart()
        {
            string androidAppSecret = "3c2c573b-b52b-4986-bf06-18dd26765e2c";
            string iOSAppSecret = "ffc63cd5-da7f-47ef-aae1-99094df028ad";
            AppCenter.Start($"android={androidAppSecret};ios={iOSAppSecret}", typeof(Crashes), typeof(Analytics));

            bool isAppCrashes = await Crashes.HasCrashedInLastSessionAsync();
            if (isAppCrashes)
            {
                var crashReport = await Crashes.GetLastSessionCrashReportAsync();
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
