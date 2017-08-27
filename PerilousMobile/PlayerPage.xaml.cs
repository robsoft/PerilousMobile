using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;



namespace PerilousMobile
{
    public partial class PlayerPage : ContentPage
    {

        private void OnMoveClickedHandler(object sender, System.EventArgs e)
        {
            // crude button for now
            Button button = (Button)sender;

            App.game.ProcessPlayerTurn(button.Text);
            App.game.CompleteTurn();

            ProcessMove();
        }

        private void ProcessMove()
        {
            RedrawMap();

            if (App.game.playerMoved)
            {
                switch (App.game.CurrentLocation())
                {
                    case MapContent.InvalidSpace:
                        // nothing to do
                        break;
                    case MapContent.ClearSpace:
                        break;
                    case MapContent.PrincessSpace:
                        ExecutePrincess();
                        break;
                    case MapContent.ExitSpace:
                        ExecuteLeave();
                        break;
                    case MapContent.PuzzleSpace:
                        ExecutePuzzle();
                        break;
                    case MapContent.LootSpace:
                        ExecuteLoot();
                        break;
                    default: // fight
                        ExecuteFight();
                        break;
                }
            }

            // now the map might have changed even if we DIDNT move, because weather,
            // but also the map might now be different again because of events
            // in the handlers above, so;
            RedrawMap();
		}


        #region Modal Dialog Handlers
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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ProcessMove();
//            RedrawMap();
        }

        private void ExecuteLeave()
        {
            Navigation.PushModalAsync(new LeavePage());
        }
        #endregion

        private void RedrawMap()
		{
            lblMap.Text = App.game.GetMapAsText();
			lblStatus.Text = " Task   : " + App.game.GetStatusText();
			lblLoot.Text   = " Loot   : " + App.game.GetLootText();
            lblCombat.Text = " Combat : " + App.game.GetCombatText();
            lblArmour.Text = " Armour : " + App.game.GetArmourText();
            lblHealth.Text = " Health : " + App.game.GetHealthText();
            lblWind.Text =   " Wind   : " + App.game.GetWindText();
		}

        public PlayerPage()
        {
            InitializeComponent();
            RedrawMap();
        }
    }
}
