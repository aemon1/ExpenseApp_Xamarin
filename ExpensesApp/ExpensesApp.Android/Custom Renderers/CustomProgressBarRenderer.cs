using Android.Content;
using ExpensesApp.Droid.Custom_Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ProgressBar), typeof(CustomProgressBarRenderer))]
namespace ExpensesApp.Droid.Custom_Renderers
{
    public class CustomProgressBarRenderer : ProgressBarRenderer
    {
        public CustomProgressBarRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ProgressBar> e)
        {
            base.OnElementChanged(e);
            
            if (double.IsNaN(e.NewElement.Progress))
                Control.ProgressDrawable.SetTint(Color.FromHex("#00B9AE").ToAndroid());
            else if (e.NewElement.Progress < 0.3)
                Control.ProgressDrawable.SetTint(Color.FromHex("#008DD5").ToAndroid());
            else if (e.NewElement.Progress < 0.5)
                Control.ProgressDrawable.SetTint(Color.FromHex("#2D76BA").ToAndroid());
            else if (e.NewElement.Progress < 0.7)
                Control.ProgressDrawable.SetTint(Color.FromHex("#5A5F9F").ToAndroid());
            else if (e.NewElement.Progress < 0.9)
                Control.ProgressDrawable.SetTint(Color.FromHex("#B3316A").ToAndroid());
            else
                Control.ProgressDrawable.SetTint(Color.FromHex("#e01a4f").ToAndroid());
           
            Control.ScaleY = 3.0f;
        }
    }
}