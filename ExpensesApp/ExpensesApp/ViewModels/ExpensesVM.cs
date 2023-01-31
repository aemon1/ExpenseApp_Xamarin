using ExpensesApp.Interfaces;
using ExpensesApp.Models;
using ExpensesApp.Views;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class ExpensesVM
    {
        public ObservableCollection<Expense> Expenses { get; set; }
        public Object AddExpenseCommand { get; set; }
        public ExpensesVM() {
            Expenses= new ObservableCollection<Expense>();
            AddExpenseCommand= new Command(AddExpense);
            GetExpenses();
        }

        public void GetExpenses()
        {
            var expenses = Expense.GetAllExpenses();
            Expenses.Clear();
            foreach (var expense in expenses)
            {
                Expenses.Add(expense);
            }

        }

        public void AddExpense()
        {
            TrackEvent();
            Application.Current.MainPage.Navigation.PushAsync(new NewExpensePage());
        }

        private async void TrackEvent()
        {
            if(await Analytics.IsEnabledAsync())
                Analytics.TrackEvent("Add Expense Clicked");
        }

        private async void TrackCrash(Exception ex, Dictionary<string, string> properties)
        {
            if (await Crashes.IsEnabledAsync())
                Crashes.TrackError(ex, properties);
        }
    }
}
