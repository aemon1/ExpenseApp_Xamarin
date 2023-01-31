using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpensesApp.Models
{
    public class Expense
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set;}
        public string Name { get; set; }
        public float Amount { get; set; }
        [MaxLength(25)]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }

        public Expense() { }

        public static int InsertExpense(Expense expense)
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath)) { 
            conn.CreateTable<Expense>();
            return conn.Insert(expense);
            }
        }

        public static List<Expense> GetAllExpenses()
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Expense>();
                return conn.Table<Expense>().ToList();
            }
        }

        public static float TotalExpenseAmount()
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Expense>();
                return conn.Table<Expense>().ToList().Sum(e=> e.Amount);
            }
        }

        public static List<Expense> GetAllExpenses(string category)
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Expense>();
                return conn.Table<Expense>().Where(e => e.Category == category).ToList();
            }
        }
    }
}
