﻿using System;
namespace PerilousMobile
{
    public partial class Game
    {

        private void DecreaseHealthForMove()
        {
            if (foundPrincess==true)
                DecreaseHealth(healthConsumedPrincess);
            else
                DecreaseHealth(healthConsumedAlone);
        }

        public void IncreaseHealthFromFood(int health)
        {
            if (foundPrincess==true)
                IncreaseHealth((int)health/2);
            else
                IncreaseHealth(health);
        }

		public void IncreaseLoot(int loot)
		{
            lootPoints = lootPoints + loot;
		}

		public bool RunMove()
        {
            int newX = xPlayer;
            int newY = yPlayer;

            // try to find an adjacent clear space
            for (int wx = newX - 1; wx <= newX + 1; wx++)
            {
                for (int wy = newY - 1; wy <= newY + 1; wy++)
                {
                    if ((CoordInRange(wx, wy)) &&
                        !((wx == xPlayer) && (wy == yPlayer)))
                    {
                        if ((map[wx, wy] == MapContent.ClearSpace) ||
                            (map[wx, wy] == MapContent.LootSpace) ||
                            (map[wx, wy] == MapContent.FoodSpace) ||
                            (map[wx, wy] == MapContent.PrincessSpace) ||
                            (map[wx, wy] == MapContent.PuzzleSpace))
                        {
                            xPlayer = wx;
                            yPlayer = wy;
                            playerMoved = true;
							// running uses twice the health
							DecreaseHealthForMove();
							DecreaseHealthForMove();
							return true;
                        }
                    }
                }
            }

            // try to find an adjacent monster space
            for (int wx = newX - 1; wx <= newX + 1; wx++)
            {
                for (int wy = newY - 1; wy <= newY + 1; wy++)
                {
                    if ((CoordInRange(wx, wy)) &&
                        !((wx == xPlayer) && (wy == yPlayer)))
                    {
                        if ((map[wx, wy] != MapContent.InvalidSpace) &&
                            (map[wx, wy] != MapContent.ExitSpace))
                        {
                            xPlayer = wx;
                            yPlayer = wy;
                            playerMoved = true;
                            // running uses twice the health
                            DecreaseHealthForMove();
							DecreaseHealthForMove();
							return true;
                        }
                    }
                }
            }

            return false;
        }



        public int FightMove(int hitPoints)
        {
            // decide if we've beaten this dude etc
            return 0;
        }

        public void TakePrincess()
        {
            foundPrincess = true;
        }

        public void EndGame()
        {
            gameOver = true;
        }

        public void DecreaseHealth(int health)
        {
            healthPoints = healthPoints - health;
            if (healthPoints < 0) healthPoints = 0;
        }

        public void IncreaseHealth(int health)
        {
            healthPoints = healthPoints + health;
            if (healthPoints > optimalHealthPoints) healthPoints = optimalHealthPoints;
        }

    }
}