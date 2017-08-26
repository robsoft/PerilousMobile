using Xamarin.Forms;

namespace PerilousMobile
{
    public partial class PerilousMobilePage : ContentPage
    {

        async void OnAboutClickedHandler (object sender, System.EventArgs e)
        {
            await Navigation.PushAsync (new AboutPage ());
        }

        async void OnResumeClickedHandler (object sender, System.EventArgs e)
        {
            // load state in here
            await Navigation.PushAsync (new MovePage ());
        }

        async void OnRestartClickedHandler (object sender, System.EventArgs e)
        {
            await Navigation.PushAsync (new RestartPage ());
        }

        async void OnTestClickedHandler (object sender, System.EventArgs e)
        {
            await Navigation.PushAsync (new TestPage ());
        }

        public PerilousMobilePage()
        {
            InitializeComponent();
        }


    }
}
