using System;
namespace PerilousMobile
{
    public enum MapContent
    {
        ClearSpace,
        InvalidSpace,
        PrincessSpace,
        ExitSpace,
        PuzzleSpace,
        LootSpace,
        MonsterStartSpace,
        MonsterEndSpace = 20
    }


    public enum WeatherContent
    {
        ClearSky,
        Fog
    }

    public partial class GameClass
    {
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
                default:
                    {
                        if ((content >= MapContent.MonsterStartSpace) &&
                            (content <= MapContent.MonsterEndSpace))
                        {
                            return "M";
                        }
                        else
                            return ".";
                    }
            }
        }

        public string WeatherDecodeText(WeatherContent content)
        {
            switch (content)
            {
                case WeatherContent.Fog: return "%";
                default:
                    {
                        return " ";
                    }
            }
        }

        public string WorldDecodeText(int x, int y)
        {
            if (weather[x, y] == WeatherContent.ClearSky)
            {
                return MapDecodeText(map[x, y]);
            }
            else
                return WeatherDecodeText(weather[x, y]);

        }

        public string GetWindText()
        {
            string wind = "";
            if (windYDirection < 0) { wind = wind + "N"; }
            else
                if (windYDirection > 0) { wind = wind + "S"; }

			if (windXDirection < 0) { wind = wind + "W"; }
			else
				if (windXDirection > 0) { wind = wind + "E"; }
			if (wind == "")
            { return "Calm"; }
            else
                return wind;
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


        public string GetMonsterText()
        {
            // don't let our internal enums bleed into gui at the moment
            int monster = (int)map[xPlayer, yPlayer];
            return monster.ToString();
        }

        private MapContent RandomMonster()
        {
            return (MapContent)rnd.Next((int)MapContent.MonsterStartSpace, (int)MapContent.MonsterEndSpace);
        }



    }
}
