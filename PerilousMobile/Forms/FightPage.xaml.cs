using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PerilousMobile
{
    public partial class FightPage : ContentPage
    {

        private MonsterClass monster;

        async void HandleFightClicked(object sender, System.EventArgs e)
        {
            // for now assume full combat points for each mover
            monster.isHealing = true;   // never gets reset now until healed or dead, even if bribe, run etc

            int monsterPerc = Utils.rnd.Next(0, 21);
            int monsterPoints = monster.healthPoints - (int)((float)monster.healthPoints * monsterPerc / 100.0f);
            if (monster.healthPoints <= 50)
                monsterPoints = monster.healthPoints;
            monster.DecreaseHealth(App.game.PlayerFightMove(App.game.combatPoints,
                                                            monster.combatPoints,
                                                            monsterPoints));
            UpdateStats();

            //await DisplayAlert("Fight", "The " + monster.FullDescription() + "'s turn", "OK");

            monster.DecreaseHealth(App.game.MonsterFightMove(monster.combatPoints,
                                                            monster.healthPoints));

            UpdateStats();

            if (App.game.healthPoints <= 0)
            {
                await DisplayAlert("Fight", "You lost the fight", "OK");
                App.game.gameOver = true;
                await Navigation.PopModalAsync();
            }
            else if (monster.healthPoints <= 0)
            {
                App.game.IncreaseLoot(monster.lootPoints);
                await DisplayAlert("Fight", "You won the fight", "OK");
                App.game.ClearCurrentLocation();
                await Navigation.PopModalAsync();
            }
            else
            {
                int outcome = Utils.rnd.Next(0, 11); // 1/10

                if ((outcome == 1) && (monster.healthPoints < App.game.healthPoints))
                {
                    await DisplayAlert("Victory", "The monster flees in fear", "OK");
                    App.game.ClearCurrentLocation();
					await Navigation.PopModalAsync();
				}
                else if (outcome == 2)
                {
                    // monster steals some loot
                    int lootGot = Utils.rnd.Next(2, (int)App.game.lootPoints / 2);
                    App.game.DecreaseLoot(lootGot);
                    monster.lootPoints = monster.lootPoints + lootGot;
                    UpdateStats();
                    await DisplayAlert("Theif", "The monster steals some of your loot", "OK");
                }
                else if ((outcome == 3) && (App.game.armourPoints > 1))
                {
                    // monster breaks some armour
                    int armourDown = Utils.rnd.Next(2, (int)App.game.armourPoints / 2);
                    App.game.DecreaseArmour(armourDown);
                    UpdateStats();
                    await DisplayAlert("Fierce", "The monster destroys some of your armour", "OK");
                }
                else if ((outcome == 4) && (monster.combatPoints >= App.game.combatPoints))
                {
                    int healthDown = 0;
                    if (App.game.healthPoints >= 50)
                        healthDown = Utils.rnd.Next(20, (int)App.game.healthPoints / 2);
                                        else healthDown = App.game.healthPoints;

                    if (healthDown>=App.game.healthPoints)
					{
                        App.game.DecreaseHealth(App.game.healthPoints);
                        UpdateStats();
                        await DisplayAlert("Fatal Blow", "The monster delivers a crushing blow", "OK");
						App.game.gameOver = true;
						await Navigation.PopModalAsync();
					}
                    else
                    {
                        // monster deals extra damage
                        App.game.DecreaseHealth(healthDown);
                        App.game.DecreaseCombat(Utils.rnd.Next(1,App.game.combatPoints));
						App.game.DecreaseArmour(1);
						UpdateStats();
                        await DisplayAlert("Fierce", "The monster delivers a heavy blow", "OK");
                    }
                }
				else if ((outcome == 4) && (monster.combatPoints < App.game.combatPoints))
				{
					int healthDown = 0;
					if (monster.healthPoints >= 40)
						healthDown = Utils.rnd.Next(10, (int)monster.healthPoints / 2);
					else healthDown = monster.healthPoints;

					if (healthDown >= monster.healthPoints)
					{
                        monster.healthPoints=0;
						App.game.IncreaseLoot(monster.lootPoints);
						UpdateStats();
						App.game.ClearCurrentLocation();
                        await DisplayAlert("Fatal Blow", "You delivered a crushing blow", "OK");
						await Navigation.PopModalAsync();
					}
					else
					{
                        // monster deals extra damage
                        monster.healthPoints = monster.healthPoints - healthDown;
                        // also stop healing
                        monster.isHealing = false;
                        if (monster.combatPoints > 1) monster.combatPoints--;
						UpdateStats();
						await DisplayAlert("Fierce", "You deliver a heavy blow", "OK");
					}
				}

			}

        }

        async void HandleBribeClicked(object sender, System.EventArgs e)
        {
            // for now, we automatically win the fight
            await DisplayAlert("Bribe", "Temp code - your bribe accepted", "OK");
            App.game.ClearCurrentLocation();
            //App.game.RemoveRandomHealth();
            await Navigation.PopModalAsync();
        }

        async void HandleRunClicked(object sender, System.EventArgs e)
        {
            if (App.game.RunMove())
            {
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Flee", "Nowhere to run to!", "OK");
            }
        }

        private void UpdateStats()
        {
            lblMonsterCombat.Text = "Combat : " + monster.combatPoints.ToString();
            lblMonsterHealth.Text = "Health : " + monster.healthPoints.ToString();
            lblMonsterLoot.Text = "Loot : $" + monster.lootPoints.ToString();

			lblPlayerCombat.Text = "Combat : " + App.game.GetCombatText();
            lblPlayerArmour.Text = "Armour : " + App.game.GetArmourText();
            lblPlayerHealth.Text = "Health : " + App.game.GetHealthText();
            lblPlayerLoot.Text = "Loot : $" + App.game.lootPoints.ToString();
		}

        public FightPage()
        {
            InitializeComponent();

            monster = App.game.GetCurrentMonster();

			lblMonsterName.Text = monster.FullDescription();
			UpdateStats();
        }
    }
}
