using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using ExpensesApp.Droid.Dependencies;
using ExpensesApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(Share))] //Dependency registeration
namespace ExpensesApp.Droid.Dependencies
{
    public class Share : IShare
    {
        public Task Show(string title, string message, string filePath)
        {
            var intent = new Intent(Intent.ActionSend);
            intent.SetType("text/plain");
            var documentUri = FileProvider.GetUriForFile(
                Forms.Context.ApplicationContext,
                "com.companyname.expensesapp.Provider",
                new Java.IO.File(filePath));
            intent.PutExtra(Intent.ExtraStream, documentUri);
            intent.PutExtra(Intent.ExtraStream, title);
            intent.PutExtra(Intent.ExtraStream, message);

            var chooseIntent = Intent.CreateChooser(intent, title);
            chooseIntent.SetFlags(ActivityFlags.GrantReadUriPermission);
            Android.App.Application.Context.StartActivity(chooseIntent);

            return Task.FromResult(true);
        }
    }
}