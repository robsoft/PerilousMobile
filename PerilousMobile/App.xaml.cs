using Xamarin.Forms;

namespace PerilousMobile
{
    
    public partial class App : Application
    {

        public static Game game;

        public App()
        {
                game = new Game();

                InitializeComponent();

                MainPage = new NavigationPage(new MenuPage());
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
