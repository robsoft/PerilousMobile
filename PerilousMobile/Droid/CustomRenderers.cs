using Android.Content;
using Android.Graphics;
using PerilousMobile.Droid.CustomRenderers;
using PerilousMobile.UserControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FontAwesomeLabel), typeof(FontAwesomeLabelRenderer))]

namespace PerilousMobile.Droid.CustomRenderers
 
{
    public class FontAwesomeLabelRenderer : LabelRenderer
    {
        public FontAwesomeLabelRenderer(Context context) : base(context)
        {
            AutoPackage = false;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Typeface = Typeface.CreateFromAsset(Android.App.Application.Context.Assets,
                    "FontAwesome.otf");
            }
        }
    }
}
