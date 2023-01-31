using ExpensesApp.Models;
using ExpensesApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpenseDetailPage : ContentPage
    {
        ExpenseDetailsVM ViewModel;
        public ExpenseDetailPage()
        {
            InitializeComponent();
        }

        public ExpenseDetailPage(Expense expense)
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as ExpenseDetailsVM;
            ViewModel.Expense = expense;
        }
    }
}