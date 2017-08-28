using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PerilousMobile
{
    public partial class InventoryPage : ContentPage
    {
		async void HandleResumeClicked(object sender, System.EventArgs e)
		{
            App.game.playerMoved = false;
			await Navigation.PopModalAsync();
		}

		async void HandleDropClicked(object sender, System.EventArgs e)
		{
			App.game.playerMoved = false;
			await Navigation.PopModalAsync();
		}

		public InventoryPage()
        {
            InitializeComponent();
        }
    }
}
