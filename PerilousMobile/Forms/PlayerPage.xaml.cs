using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;


namespace PerilousMobile
{
    public partial class PlayerPage : ContentPage
    {

        private bool showKey = false;

        async protected override void OnAppearing()
        {
            base.OnAppearing();
            if (App.game.gameOver)
                await Navigation.PopAsync();
            else
                ProcessMove();
        }

        private void OnInventoryClickedHandler(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new InventoryPage());
        }


        private void OnMoveClickedHandler(object sender, System.EventArgs e)
        {
            // crude button for now
            Button button = (Button)sender;

            App.game.ProcessPlayerTurn(button.Text);
            App.game.CompleteTurn();

            ProcessMove();
        }

        private void OnShowKeyClickedHandler(object sender, System.EventArgs e)
        {
            showKey = !showKey;
            RedrawMap();
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
                        ShowPrincessPage();
                        break;
                    case MapContent.ExitSpace:
                        ShowLeavePage();
                        break;
                    case MapContent.PuzzleSpace:
                        ShowPuzzlePage();
                        break;
                    case MapContent.LootSpace:
                        ShowLootPage();
                        break;
                    case MapContent.WeaponSpace:
                        ShowWeaponPage();
                        break;
                    case MapContent.FoodSpace:
                        ShowFoodPage();
                        break;
                    case MapContent.MonsterSpace:
                        ShowFightPage();
                        break;
                    default: // fight
                        break;
                }
            }

            // now the map might have changed even if we DIDNT move, because weather,
            // but also the map might now be different again because of events
            // in the handlers above, so;
            RedrawMap();
        }

        #region Modal Dialog Handlers
        private void ShowFightPage()
        {
            Navigation.PushModalAsync(new FightPage());
        }

        private void ShowLootPage()
        {
            Navigation.PushModalAsync(new LootPage());
        }

        private void ShowPuzzlePage()
        {
            Navigation.PushModalAsync(new PuzzlePage());
        }

        private void ShowWeaponPage()
        {
            Navigation.PushModalAsync(new WeaponPage());
        }

        private void ShowFoodPage()
        {
            Navigation.PushModalAsync(new FoodPage());
        }

        private void ShowPrincessPage()
        {
            Navigation.PushModalAsync(new PrincessPage());
        }

        private void ShowLeavePage()
        {
            Navigation.PushModalAsync(new LeavePage());
        }
        #endregion


        private void canvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e) 
        {

            //SKSurface surface = e.Surface;
            //SKCanvas canvas = surface.Canvas;

            App.game.DrawMap(e);

        }

        private void RedrawMap()
		{
            //lblMap.Text = App.game.GetMapAsText();
            canvasView.InvalidateSurface();

			lblStatus.Text = " Task - " + App.game.GetStatusText();

			lblLoot.Text   = "  Loot   : " + App.game.GetLootText();
            lblCombat.Text = "  Combat : " + App.game.GetCombatText();
            lblArmour.Text = "  Armour : " + App.game.GetArmourText();
            lblHealth.Text = "  Health : " + App.game.GetHealthText();
            btnNW.IsEnabled = App.game.CanMoveNW();
            btnNO.IsEnabled = App.game.CanMoveN();
            btnNE.IsEnabled = App.game.CanMoveNE();
            btnWE.IsEnabled = App.game.CanMoveW();
            btnEA.IsEnabled = App.game.CanMoveE();
            btnSW.IsEnabled = App.game.CanMoveSW();
            btnSO.IsEnabled = App.game.CanMoveS();
            btnSE.IsEnabled = App.game.CanMoveSE();
            btnInv.IsEnabled = App.game.CanInventory();
            btnKey.IsEnabled = App.game.CanShowKey();

            // test showKey etc
            //showKey = true;
            //stkMoves.IsVisible = !showKey;
            stkKey.IsVisible = showKey;
            stkStats.IsVisible = !showKey;
            btnKey.Text = showKey ? "Show Stats" : "Show Key";

		}

        public PlayerPage()
        {
            InitializeComponent();

            RedrawMap();
        }
    }
}
