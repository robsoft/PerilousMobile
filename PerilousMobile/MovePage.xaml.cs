using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PerilousMobile
{
    public partial class MovePage : ContentPage
    {

        async void OnMapClickedHandler (object sender, System.EventArgs e)
        {
            await Navigation.PushAsync (new MapPage ());
        }

        async void OnFightClickedHandler (object sender, System.EventArgs e)
        {
            await Navigation.PushAsync (new FightPage ());
        }

        async void OnPuzzleClickedHandler (object sender, System.EventArgs e)
        {
            await Navigation.PushAsync (new PuzzlePage ());
        }

        async void OnMoveClickedHandler (object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            await DisplayAlert("clicked", "Clicked "+button.Text , "Ok");
        }


        public MovePage()
        {
            InitializeComponent();
        }
    }
}
