using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PerilousMobile
{
    public partial class PuzzlePage : ContentPage
    {
        async void HandleDoneClicked(object sender, System.EventArgs e)
        {
            // assume puzzle solved for now
            App.game.ClearCurrentLocation();
            await Navigation.PopModalAsync();
        }

		async void HandleLeaveClicked(object sender, System.EventArgs e)
		{
			App.game.playerMoved = false;
			await Navigation.PopModalAsync();
		}

		public PuzzlePage()
        {
            InitializeComponent();
        }
    }
}
