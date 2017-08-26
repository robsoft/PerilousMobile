using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PerilousMobile
{
    public partial class FightPage : ContentPage
    {
        async void HandleDoneClicked(object sender, System.EventArgs e)
        {
			await Navigation.PopModalAsync();

		}

        public FightPage()
        {
            InitializeComponent();

            btnDone.Text = "Monster type " + App.game.CurrentLocation().ToString();
        }
    }
}
