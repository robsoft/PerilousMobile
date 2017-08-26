using Xamarin.Forms;

namespace PerilousMobile
{
    
    public partial class App : Application
    {

        public static GameClass game;

        public App()
        {
            InitializeComponent();

            game = new GameClass();


            MainPage = new NavigationPage(new PerilousMobilePage());
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
