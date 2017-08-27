using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PerilousMobile
{
    public partial class FightPage : ContentPage
    {
        async void HandleDoneClicked(object sender, System.EventArgs e)
        {
            // for now, we automatically win the fight
            App.game.ClearCurrentLocation();
            App.game.RemoveRandomHealth();
            await Navigation.PopModalAsync();
		}

		async void HandleRunClicked(object sender, System.EventArgs e)
		{
            if (App.game.RunMove())
            {
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Flee", "Nowhere to run to!", "OK");
            }
		}

		public FightPage()
        {
            InitializeComponent();

            btnDone.Text = "Monster type " + App.game.GetMonsterText();
        }
    }
}
