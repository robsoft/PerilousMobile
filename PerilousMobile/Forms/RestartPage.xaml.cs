using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PerilousMobile
{
    public partial class RestartPage : ContentPage
    {

        async void OnRegenerateClickedHandler (object sender, System.EventArgs e)
        {
            App.game.PopulateMap();
            await DisplayAlert("Reset","Map Reset","OK");
        }

        public RestartPage()
        {
            InitializeComponent();
        }
    }
}
