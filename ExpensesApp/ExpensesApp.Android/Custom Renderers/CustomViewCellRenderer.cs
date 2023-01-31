using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using ExpensesApp.Droid.Custom_Renderers;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ViewCell),typeof(CustomViewCellRenderer))]
namespace ExpensesApp.Droid.Custom_Renderers
{
    public class CustomViewCellRenderer : ViewCellRenderer
    {
        private Android.Views.View cell;
        private bool isSelected;
        private Drawable defaultBackground;

        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            cell = base.GetCellCore(item, convertView, parent, context);
            isSelected = false;
            defaultBackground = cell.Background;
            return cell;
        }

        protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnCellPropertyChanged(sender, e);

            if(e.PropertyName == "IsSelected")
            {
                isSelected = !isSelected;

                if (isSelected)
                {
                    cell.SetBackgroundColor(Color.FromHex("#E6E6E6").ToAndroid());
                }
                else
                {
                    cell.Background = defaultBackground;
                }
            }
        }
    }
}