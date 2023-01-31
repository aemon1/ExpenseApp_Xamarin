using ExpensesApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ExpensesApp.ViewModels
{
    public class ExpenseDetailsVM : INotifyPropertyChanged
    {
        private Expense expense;
        public Expense Expense {
            get { return expense; }
            set
            {
                expense = value;
                OnPropertyChanged("Expense");
            } 
        }

        public ExpenseDetailsVM() { }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}
