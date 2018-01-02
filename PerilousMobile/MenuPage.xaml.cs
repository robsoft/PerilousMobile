using Xamarin.Forms;

namespace PerilousMobile
{
    public partial class MenuPage : ContentPage
    {

        protected override void OnAppearing()
        {
            base.OnAppearing();

            btnResume.IsEnabled = (App.game.currentState == GameState.isInPlay);

            // if we've hit this event and we're 'readytostart' then kick off the game
            if (App.game.currentState == GameState.isReadyToStart)
                Device.StartTimer(new System.TimeSpan(0, 0, 0, 0, 500), () =>
                      {
                          OnResumeClickedHandler(null, null);
                          return false; // stop recurring timer!
                      });
        }

        async void OnAboutClickedHandler(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }

        async void OnResumeClickedHandler(object sender, System.EventArgs e)
        {
            // resume game from wherever we are (a 'start new' comes in via a resume, too)
            App.game.currentState = GameState.isInPlay;
            await Navigation.PushAsync(new PlayerPage());
        }

        async void OnStartClickedHandler(object sender, System.EventArgs e)
        {
            // make sure any old game is lost
            App.game.currentState = GameState.isOver;
            // now cause a regeneration etc
            await Navigation.PushModalAsync(new SelectionPage());
        }

        async void OnBackStoryClickedHandler(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new BackStoryPage());
        }

        public MenuPage()
        {
            InitializeComponent();
        }


    }
}
