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
	public partial class CategoriesPage : ContentPage
	{
		CategoriesVM categoriesVM;
		public CategoriesPage ()
		{
			InitializeComponent ();
			categoriesVM = Resources["vm"] as CategoriesVM;
            SizeChanged += CategoriesPage_SizeChanged;
		}

        private void CategoriesPage_SizeChanged(object sender, EventArgs e)
        {
            string visualState = Width > Height ? "Landscape" : "Portrait";
            VisualStateManager.GoToState(titleLabel,visualState);
        }

        void Handle_Pressed(object sender, EventArgs e)
        {
            VisualStateManager.GoToState(exampleButton, "Focused");
        }

        void Handle_Released(object sender, EventArgs e)
        {
            VisualStateManager.GoToState(exampleButton, "Normal");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
			categoriesVM.GetExpensesPerCategory();
        }
    }
}