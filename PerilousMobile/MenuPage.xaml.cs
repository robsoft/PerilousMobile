using Xamarin.Forms;

namespace PerilousMobile
{
    public partial class MenuPage : ContentPage
    {

        async void OnAboutClickedHandler (object sender, System.EventArgs e)
        {
            await Navigation.PushAsync (new AboutPage ());
        }

        async void OnResumeClickedHandler (object sender, System.EventArgs e)
        {
            if (App.game.gameOver)
				App.game.Reset();
            
			await Navigation.PushAsync(new PlayerPage());
        }

        async void OnRestartClickedHandler (object sender, System.EventArgs e)
        {
            //await Navigation.PushAsync (new RestartPage ());

            var answer = await(DisplayAlert("Start New Game?", "Any previous progress will be lost?", "Yes", "No"));
            if (answer)
            {
                App.game.Reset();
                OnResumeClickedHandler(null,null);
            }

        }

        async void OnHelpClickedHandler (object sender, System.EventArgs e)
        {
            await Navigation.PushAsync (new HelpPage ());
        }

        public MenuPage()
        {
            InitializeComponent();
        }


    }
}
