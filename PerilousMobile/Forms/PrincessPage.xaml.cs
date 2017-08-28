using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PerilousMobile
{
    public partial class PrincessPage : ContentPage
    {
        async void HandleDoneClicked(object sender, System.EventArgs e)
        {
			App.game.ClearCurrentLocation();
			App.game.TakePrincess();
            await Navigation.PopModalAsync();
        }

		async void HandleLeaveClicked(object sender, System.EventArgs e)
		{
			App.game.playerMoved = false;
			await Navigation.PopModalAsync();
		}

		public PrincessPage()
        {
            InitializeComponent();
        }
    }
}
