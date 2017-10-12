using Android.App;
using Android.Widget;
using Android.OS;
using NUnit.Framework;
using Android.Content.PM;
using NUnit.Runner.Services;

namespace PerilousMobile.Tests.Droid
{
    [Activity(Label = "NUnit 3", MainLauncher = true, Theme = "@android:style/Theme.Holo.Light", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            // This will load all tests within the current project
            var nunit = new NUnit.Runner.App();

            // If you want to add tests in another assembly
            //nunit.AddTestAssembly(typeof(MyTests).Assembly);

            // Do you want to automatically run tests when the app starts?
            nunit.Options = new TestOptions
            {
                AutoRun = true
            };

            LoadApplication(nunit);
        }
    }
}
