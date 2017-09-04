using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PerilousMobile
{
    public partial class FightPage : ContentPage
    {

        private MonsterClass monster;

        async void HandleFightClicked(object sender, System.EventArgs e)
        {
            // for now, we automatically win the fight
            await DisplayAlert("Fight", "Temp code - you win the fight", "OK");
            App.game.ClearCurrentLocation();
            //App.game.RemoveRandomHealth();
            await Navigation.PopModalAsync();
		}

		async void HandleBribeClicked(object sender, System.EventArgs e)
		{
            // for now, we automatically win the fight
            await DisplayAlert("Bribe", "Temp code - your bribe accepted", "OK");
			App.game.ClearCurrentLocation();
			//App.game.RemoveRandomHealth();
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

            monster = App.game.GetCurrentMonster();

            lblCombat.Text = "Combat : "+monster.combatPoints.ToString();
            lblHealth.Text = "Health : " + monster.healthPoints.ToString();
            lblName.Text = monster.FullDescription();

        }
    }
}
