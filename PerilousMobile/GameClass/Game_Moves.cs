using System;
namespace PerilousMobile
{
    public partial class Game
    {

        public bool CanMoveN()
        {
            int y = yPlayer - 1;
            return ((CoordInRange(xPlayer, y) == true) && (map[xPlayer, y] != MapContent.InvalidSpace));
        }

        public bool CanMoveS()
        {
            int y = yPlayer + 1;
            return ((CoordInRange(xPlayer, y) == true) && (map[xPlayer, y] != MapContent.InvalidSpace));
        }
        public bool CanMoveE()
        {
            int x = xPlayer + 1;
            return ((CoordInRange(x, yPlayer) == true) && (map[x, yPlayer] != MapContent.InvalidSpace));
        }
        public bool CanMoveW()
        {
            int x = xPlayer - 1;
            return ((CoordInRange(x, yPlayer) == true) && (map[x, yPlayer] != MapContent.InvalidSpace));
        }

        public bool CanMoveNE()
        {
            int y = yPlayer - 1;
            int x = xPlayer + 1;
            return ((CoordInRange(x, y) == true) && (map[x, y] != MapContent.InvalidSpace));
        }

        public bool CanMoveNW()
        {
            int y = yPlayer - 1;
            int x = xPlayer - 1;
            return ((CoordInRange(x, y) == true) && (map[x, y] != MapContent.InvalidSpace));
        }
        public bool CanMoveSE()
        {
            int y = yPlayer + 1;
            int x = xPlayer + 1;
            return ((CoordInRange(x, y) == true) && (map[x, y] != MapContent.InvalidSpace));
        }
        public bool CanMoveSW()
        {
            int y = yPlayer + 1;
            int x = xPlayer - 1;
            return ((CoordInRange(x, y) == true) && (map[x, y] != MapContent.InvalidSpace));
        }

        public bool CanInventory()
        {
            return true;
        }

        public bool CanShowKey()
        {
            return true;
        }

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



        public int MonsterFightMove(int monsterCombat, int monsterHealth)
        {
            if ((combatPoints > 0) && (healthPoints > 0) && (monsterHealth>0))
            {
                // higher player armour tends to offset higher monster combat
                float combatCoef = (float)monsterCombat / ((float)combatPoints + ((float)armourPoints / 2.5f));
				combatCoef = Math.Max(0.002f, combatCoef);
				combatCoef = Math.Min(2.1f, combatCoef);
				
                float healthCoef = ((float)monsterHealth / (float)healthPoints);
                float playerHealthUsed = (float)healthCoef * (float)combatCoef * (float)monsterHealth / 4.0f;
                playerHealthUsed = Math.Min(playerHealthUsed, (float)healthPoints);
                float monsterHealthUsed = (float)playerHealthUsed * (float)combatCoef / 4.0f;
				float monsterHealthMax = Math.Min(monsterHealthUsed, (float)monsterHealth);

				DecreaseHealth((int)playerHealthUsed);
                DecreaseArmour((int)(1.0f / combatCoef));
                return (int)monsterHealthMax;
            }
            else
                return 0;
        }

		public int PlayerFightMove(int playerCombat, int monsterCombat, int monsterHealth)
		{
            if ((monsterCombat > 0) && (healthPoints > 0) && (monsterHealth > 0))
            {
                float combatCoef = ((float)playerCombat + ((float)armourPoints / 4.0f)) / (float)monsterCombat;
                combatCoef = Math.Max(0.002f, combatCoef);
				combatCoef = Math.Min(2.1f, combatCoef);

                float healthCoef = (float)healthPoints / (float)monsterHealth;
                float monsterHealthUsed = (float)healthCoef * (float)combatCoef * (float)monsterHealth / 4.0f;
                float monsterHealthMax = Math.Min(monsterHealthUsed, (float)monsterHealth);
                float playerHealthUsed = (float)monsterHealthMax * (float)combatCoef / 4.0f;
                playerHealthUsed = Math.Min(playerHealthUsed, (float)healthPoints);

                DecreaseHealth((int)playerHealthUsed);

                return (int)monsterHealthMax;
            }
            else
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

		public void DecreaseArmour(int armour)
		{
            armourPoints = armourPoints - armour;
            if (armourPoints < 1) armourPoints = 1;
		}

		public void DecreaseCombat(int combat)
		{
            combatPoints = combatPoints - combat;
			if (combatPoints < 1) combatPoints = 1;
		}

        public void DecreaseLoot(int loot)
		{
			lootPoints = lootPoints - loot;
			if (lootPoints < 0) lootPoints = 0;
		}

		public void IncreaseHealth(int health)
        {
            healthPoints = healthPoints + health;
            if (healthPoints > optimalHealthPoints) healthPoints = optimalHealthPoints;
        }

    }
}
