using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PerilousMobile
{
    public partial class LootPage : ContentPage
    {
        private LootClass loot;

        async void HandleTakeClicked(object sender, System.EventArgs e)
        {
            App.game.ClearCurrentLocation();
            App.game.IncreaseLoot(loot.lootPoints);
            await Navigation.PopModalAsync();

        }

		async void HandleLeaveClicked(object sender, System.EventArgs e)
		{
            App.game.playerMoved = false;
			await Navigation.PopModalAsync();

		}

		public LootPage()
        {
            InitializeComponent();
            loot = App.game.GetCurrentLoot();

            lblValue.Text = "Value " + loot.lootPoints.ToString();
			lblName.Text = loot.FullDescription();

		}
    }
}
