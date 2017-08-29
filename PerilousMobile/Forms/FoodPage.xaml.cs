using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PerilousMobile
{
    public partial class FoodPage : ContentPage
    {
   
        private FoodClass food;

		async void HandleEatClicked(object sender, System.EventArgs e)
		{
			App.game.IncreaseHealthFromFood(food.healthPoints);
			App.game.ClearCurrentLocation();
			await Navigation.PopModalAsync();
		}

		async void HandleLeaveClicked(object sender, System.EventArgs e)
		{
			App.game.playerMoved = false;
			await Navigation.PopModalAsync();
		}

		public FoodPage()
		{
			InitializeComponent();

            food = App.game.GetCurrentFood();

			lblName.Text = food.FullDescription();
			lblHealth.Text = "Health " + food.healthPoints.ToString();

		}

    }
}
