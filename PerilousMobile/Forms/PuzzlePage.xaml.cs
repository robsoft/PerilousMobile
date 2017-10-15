using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PerilousMobile
{
    public partial class PuzzlePage : ContentPage
    {

        private PuzzleClass puzzle;

        async void HandleDoneClicked(object sender, System.EventArgs e)
        {
            // assume puzzle solved for now
            App.game.ClearCurrentLocation();
            if (App.game.haveMap == false)
            {
                App.game.haveMap = true;
                await DisplayAlert("Temp Puzzle", "You have found a map", "Ok");
            }
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

			puzzle = App.game.GetCurrentPuzzle();

			//lblCombat.Text = "Combat " + monster.combatPoints.ToString();
            //lblHealth.Text = "Health " + monster.healthPoints.ToString();
            lblName.Text = puzzle.FullDescription();
        }
    }
}
