using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PerilousMobile
{
    public partial class PlayerPage : ContentPage
    {

		private void OnMoveClickedHandler(object sender, System.EventArgs e)
		{
            // crude button for now
			Button button = (Button)sender;
            /*if (!App.game.MovePlayerText(button.Text))
            {
                await DisplayAlert("Move", "Can't move " + button.Text, "Ok");
            }
            else*/
			if (App.game.MovePlayerText(button.Text))
			{
                RedrawMap();

                switch (App.game.CompleteMove())
                {
					case 0:
						// nothing to do
						break;
                    case 1:
                        break;
					case 2:
						ExecutePrincess();
						break;
					case 3:
						ExecuteLeave();
						break;
					case 4: // puzzle
						ExecutePuzzle();
						break;
					case 5:
                        ExecuteLoot();
						break;
					default: // fight
                        ExecuteFight();
                        break;
                }
                      
            }
		}


        private void ExecuteFight()
        {
			Navigation.PushModalAsync(new FightPage());
		}
		private void ExecuteLoot()
		{
			Navigation.PushModalAsync(new LootPage());
		}
		private void ExecutePuzzle()
		{
            Navigation.PushModalAsync(new PuzzlePage());
		}
		private void ExecutePrincess()
		{
			Navigation.PushModalAsync(new PrincessPage());
		}
		private void ExecuteLeave()
		{
            Navigation.PushModalAsync(new LeavePage());
		}

		private void RedrawMap()
		{
            lblMap.Text = App.game.GetMapAsText();
		}

        public PlayerPage()
        {
            InitializeComponent();
            RedrawMap();
        }
    }
}
