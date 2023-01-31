using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesApp.Interfaces
{
    public interface IShare
    {
        Task Show(string title, string message, string filePath);
    }
}
