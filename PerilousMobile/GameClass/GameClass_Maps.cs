using System;
namespace PerilousMobile
{
    public partial class GameClass
    {



		public void PopulateMap()
		{
			// we want some nice maze generation code here, but for now
			for (int i = 0; i < xDim; i++)
			{
				for (int j = 0; j < yDim; j++)
				{
					map[i, j] = MapContent.InvalidSpace;
				}
			}

			// chance of an inner block NOT being cleared
			for (int i = 1; i < (xDim - 1); i++)
			{
				for (int j = 1; j < (yDim - 1); j++)
				{
					if (rnd.Next(1, 16) > 1)    // 1 in 15 chance
						map[i, j] = MapContent.ClearSpace;
				}
			}

			// princess
			int x = rnd.Next(2, xDim - 2);
			int y = rnd.Next(2, yDim - 2);
			map[x, y] = MapContent.PrincessSpace;

			// entrance/exit
			int eCount = rnd.Next(1, 3);    // ie 1 or 2 sets of '2 exits'
			for (int i = 0; i <= eCount; i++)
			{
				do
				{
					// want to decide if left hand side or right hand side
					x = (xDim - 1) * rnd.Next(0, 2);    // ie, 0 or xDim-1
					y = rnd.Next(1, yDim - 1);
					if (map[x, y] == MapContent.InvalidSpace)
					{
						map[x, y] = MapContent.ExitSpace;
						break;
					}
				} while (true);

				do
				{
					// want to decide if top or bottom
					x = rnd.Next(1, xDim - 1);
					y = (yDim - 1) * rnd.Next(0, 2);    // ie, 0 or yDim-1
					if (map[x, y] == MapContent.InvalidSpace)
					{
						map[x, y] = MapContent.ExitSpace;
						break;
					}
				} while (true);

			}

			// puzzles
			int pCount = 0;
			while (pCount < puzzleCount)
			{
				x = rnd.Next(1, xDim - 1);
				y = rnd.Next(1, yDim - 1);

				if (map[x, y] == MapContent.ClearSpace)
				{
					map[x, y] = MapContent.PuzzleSpace;
					AddPuzzle(x, y);
					pCount++;
				}
			}

			// weapons
			int wCount = 0;
			while (wCount < weaponCount)
			{
				x = rnd.Next(1, xDim - 1);
				y = rnd.Next(1, yDim - 1);

				if (map[x, y] == MapContent.ClearSpace)
				{
					map[x, y] = MapContent.WeaponSpace;
					AddWeapon(x, y);
					wCount++;
				}
			}

			// loot
			int lCount = 0;
			while (lCount < lootCount)
			{
				x = rnd.Next(1, xDim - 1);
				y = rnd.Next(1, yDim - 1);

				if (map[x, y] == MapContent.ClearSpace)
				{
					map[x, y] = MapContent.LootSpace;
					AddLoot(x, y);
					lCount++;
				}
			}

			// food
			int fCount = 0;
			while (fCount < foodCount)
			{
				x = rnd.Next(1, xDim - 1);
				y = rnd.Next(1, yDim - 1);

				if (map[x, y] == MapContent.ClearSpace)
				{
					map[x, y] = MapContent.FoodSpace;
					AddFood(x, y);
					fCount++;
				}
			}

			// monsters
			int mCount = 0;
			ClearMonsters();
			while (mCount < monsterCount)
			{
				x = rnd.Next(1, xDim - 1);
				y = rnd.Next(1, yDim - 1);

				if (map[x, y] == MapContent.ClearSpace)
				{
					map[x, y] = MapContent.MonsterSpace;
					AddMonster(x, y);
					mCount++;
				}
			}

			// now position the dude
			do
			{
				x = (xDim - 1) * rnd.Next(0, 2);    // ie, 0 or xDim-1
				y = rnd.Next(1, yDim - 1);
				if (map[x, y] == MapContent.ExitSpace)
				{
					xPlayer = x;
					yPlayer = y;
					break;
				}
			} while (true);//

		}

		private bool CoordInRange(int wx, int wy)
		{
			return ((wx >= 0) && (wx < xDim) && (wy >= 0) && (wy < yDim));
		}


		private void AddFood(int xCoord, int yCoord)
		{
			FoodClass thisFood = new FoodClass(xCoord, yCoord);
			food.Add(thisFood);
		}

		private void AddMonster(int xCoord, int yCoord)
		{
			MonsterClass thisMonster = new MonsterClass(xCoord, yCoord);
			monsters.Add(thisMonster);
		}
		private void AddPuzzle(int xCoord, int yCoord)
		{
			PuzzleClass thisPuzzle = new PuzzleClass(xCoord, yCoord);
			puzzles.Add(thisPuzzle);
		}

		private void AddLoot(int xCoord, int yCoord)
		{
			LootClass thisLoot = new LootClass(xCoord, yCoord);
			loot.Add(thisLoot);
		}

		private void AddWeapon(int xCoord, int yCoord)
		{
			WeaponClass thisWeapon = new WeaponClass(xCoord, yCoord);
			weapons.Add(thisWeapon);
		}



	}
}