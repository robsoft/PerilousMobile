using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PerilousMobile
{
    public partial class WeaponPage : ContentPage
    {

		private WeaponClass weapon;

		async void HandleTakeClicked(object sender, System.EventArgs e)
		{
			App.game.ClearCurrentLocation();
			//App.game.AddRandomLoot();
			await Navigation.PopModalAsync();

		}

		async void HandleLeaveClicked(object sender, System.EventArgs e)
		{
			App.game.playerMoved = false;
			await Navigation.PopModalAsync();

		}

        public WeaponPage()
        {
            InitializeComponent();

			weapon = App.game.GetCurrentWeapon();

            lblCombat.Text = "Adds " + weapon.combatPoints.ToString() + " Combat";
			lblName.Text = weapon.FullDescription();

		}
    }
}
