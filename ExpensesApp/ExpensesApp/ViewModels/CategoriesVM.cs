using ExpensesApp.Interfaces;
using ExpensesApp.Models;
using PCLStorage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class CategoriesVM
    {
        public ObservableCollection<string> Categories { get; set; }

        public Command ExportCommand {  get; set; }
        public ObservableCollection<CategoryExpenses> CategoryExpensesCollection { get; set; }
        
        public CategoriesVM() {
            ExportCommand = new Command(ShareReport);
            Categories = new ObservableCollection<string>();
            CategoryExpensesCollection= new ObservableCollection<CategoryExpenses>();
            GetCategories();
            GetExpensesPerCategory();
        }

        public void GetExpensesPerCategory()
        {
            CategoryExpensesCollection.Clear();
            float totalExpenseAmount = Expense.TotalExpenseAmount();
            foreach (var category in Categories)
            {
                var expenses = Expense.GetAllExpenses(category);
                float expenseAmountOfCategory = expenses.Sum(e => e.Amount);
                CategoryExpenses categoryExpenses = new CategoryExpenses()
                {
                    Category = category,
                    ExpensesPercentage = expenseAmountOfCategory / totalExpenseAmount
                };

                CategoryExpensesCollection.Add(categoryExpenses);
            }
        }

        public async void ShareReport()
        {
            IFileSystem fileSystem = FileSystem.Current;
            IFolder rootFolder = fileSystem.LocalStorage;
            IFolder reportsFolder = await rootFolder.CreateFolderAsync("reports", CreationCollisionOption.OpenIfExists);

            var txtFile = await reportsFolder.CreateFileAsync("report.txt", CreationCollisionOption.ReplaceExisting);

            using(StreamWriter sw = new StreamWriter(txtFile.Path))
            {
                foreach(var categoryExpense in CategoryExpensesCollection)
                {
                    sw.WriteLine($"{categoryExpense.Category} - {categoryExpense.ExpensesPercentage}");
                }
            }
            // This will work with both Android and iOS Share method
            IShare shareDependency = DependencyService.Get<IShare>();
            shareDependency.Show("", "", "");
        }

        private void GetCategories()
        {
            Categories.Clear();
            Categories.Add("Housing");
            Categories.Add("Debt");
            Categories.Add("Health");
            Categories.Add("Food");
            Categories.Add("Personal");
            Categories.Add("Travel");
            Categories.Add("Other");
        }
    }
}
