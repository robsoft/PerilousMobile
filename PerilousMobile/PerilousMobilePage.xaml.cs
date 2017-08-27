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
            await Navigation.PushAsync(new PlayerPage());
        }

        //async 
        void OnRestartClickedHandler (object sender, System.EventArgs e)
        {
            //await Navigation.PushAsync (new RestartPage ());
            App.game.Reset();
        }

        async void OnHelpClickedHandler (object sender, System.EventArgs e)
        {
            await Navigation.PushAsync (new HelpPage ());
        }

        public PerilousMobilePage()
        {
            InitializeComponent();
        }


    }
}
