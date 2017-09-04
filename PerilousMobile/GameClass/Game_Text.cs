using System;
namespace PerilousMobile
{
	public partial class Game
	{
		private string GetLineAsText(int line)
		{
			string lineText = "";

			for (int x = 0; x < xDim; x++)
			{
				if ((line == yPlayer) && (x == xPlayer))
				{
					lineText = lineText + "@";
				}
				else
				{
					lineText = lineText + WorldDecodeText(x, line);
				}
			}

			return lineText;
		}


		public string GetMapAsText()
		{

			string mapText = "";
			for (int y = 0; y < yDim; y++)
			{
				mapText = mapText + GetLineAsText(y) + "\n";
			}
			return mapText;
		}

		public string MapDecodeText(MapContent content)
		{
			switch (content)
			{
				case MapContent.ClearSpace: return " ";
				case MapContent.InvalidSpace: return "X";
				case MapContent.PrincessSpace: return "P";
				case MapContent.ExitSpace: return "E";
				case MapContent.LootSpace: return "$";
				case MapContent.PuzzleSpace: return "?";
				case MapContent.MonsterSpace: return "M";
				case MapContent.WeaponSpace: return "w";
				case MapContent.FoodSpace: return "f";
				default:
					{
							return ".";
					}
			}
		}

	
		public string WorldDecodeText(int x, int y)
		{
            /*
			if (weather[x, y] == WeatherContent.ClearSky)
			{
				return MapDecodeText(map[x, y]);
			}
			else
				return WeatherDecodeText(weather[x, y]);
*/
            if (PlayerCanSeeLocation(x, y))
                return MapDecodeText(map[x, y]);
            else
                return "#";

		}

        public string GetHealthText()
		{
			return healthPoints.ToString();
		}

		public string GetArmourText()
		{
			return armourPoints.ToString();
		}


		public string GetCombatText()
		{
			return combatPoints.ToString();
		}

		public string GetLootText()
		{
			return "$" + lootPoints.ToString();
		}

		public string GetStatusText()
		{
			if (foundPrincess)
			{
				return "Find an exit";
			}
			else
			{
				return "Find the Princess";
			}
		}

        /*
		public string GetMonsterText()
		{
			// don't let our internal enums bleed into gui at the moment
			int monster = (int)map[xPlayer, yPlayer];
			return monster.ToString();
		}
*/


	}

}
