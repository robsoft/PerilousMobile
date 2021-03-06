﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PerilousMobile
{
    public partial class LeavePage : ContentPage
    {
		async void HandleExitClicked(object sender, System.EventArgs e)
		{
            App.game.EndGame();
			await Navigation.PopModalAsync();
		}

		async void HandleContinueClicked(object sender, System.EventArgs e)
		{
			App.game.playerMoved = false;
			await Navigation.PopModalAsync();
		}


		public LeavePage()
        {
            InitializeComponent();
        }
    }
}
