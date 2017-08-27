﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PerilousMobile
{
    public partial class LootPage : ContentPage
    {
        async void HandleDoneClicked(object sender, System.EventArgs e)
        {
            App.game.ClearCurrentLocation();
            App.game.AddRandomLoot();
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
        }
    }
}
