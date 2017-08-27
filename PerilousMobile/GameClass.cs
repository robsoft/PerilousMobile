using System;
namespace PerilousMobile
{
    public partial class GameClass
    {

        private const int xDim = 28;
        private const int yDim = 18;
        private const int lootCount = (int)((xDim * yDim) * 0.04);
        private const int monsterCount = (int)((xDim * yDim) * 0.1);
        private const int puzzleCount = (int)((xDim * yDim) * 0.07);
        private const int weatherInitialCount = 2;
        private const int weatherUpdateFrequency = 2;

        private MapContent[,] map = new MapContent[xDim, yDim];
        private WeatherContent[,] weather = new WeatherContent[xDim, yDim];

        private int windXDirection = 0;
        private int windYDirection = 0;

        private Random rnd = new Random();

        public int xPlayer = 0;
        public int yPlayer = 0;
        public bool playerMoved = false;
        public int moveCount = 0;
        private int healthPoints = 0;
        private int armourPoints = 0;
        private int lootPoints = 0;
        private int combatPoints = 0;
        private bool foundPrincess = false;



        public MapContent CompleteTurn()
        {
            UpdateWeather();
            return (map[xPlayer, yPlayer]);
        }

        public MapContent CurrentLocation()
        {
            return (map[xPlayer, yPlayer]);
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
                            (map[wx, wy] == MapContent.PrincessSpace) ||
                            (map[wx, wy] == MapContent.PuzzleSpace))
                        {
                            xPlayer = wx;
                            yPlayer = wy;
                            playerMoved = true;
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

        public void AddRandomLoot()
        {
            lootPoints = lootPoints + rnd.Next(1, 501);
        }

        public void RemoveRandomHealth()
        {
            healthPoints = healthPoints - rnd.Next(1, healthPoints);
        }

        public void ProcessPlayerTurn(string move)
        {
            int newy = yPlayer;
            int newx = xPlayer;
            playerMoved = false;

            // calculate new position, or bail if bad
            if (move.Contains("N"))
            { newy = yPlayer - 1; }
            else if (move.Contains("S"))
            { newy = yPlayer + 1; }

            if (move.Contains("E"))
            { newx = xPlayer + 1; }
            else if (move.Contains("W"))
            { newx = xPlayer - 1; }

            // first off, a bad move into an out of range
            if ((newx < 0) || (newx >= xDim) ||
                (newy < 0) || (newy >= yDim))
                return;

            // a valid move, or 'biding time', so increase move count
            moveCount++;

            if ((newx == xPlayer) && (newy == yPlayer))
            { return; }    // we didn't actually move anywhere new, but don't flag error

            // is it a legal move? Can't be a solid block
            if (map[newx, newy] == MapContent.InvalidSpace)
            {
                return;
            }

            // update our position and signal we moved
            playerMoved = true;
            xPlayer = newx;
            yPlayer = newy;
        }

        public void ClearCurrentLocation()
        {
            map[xPlayer, yPlayer] = MapContent.ClearSpace;
        }

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
                    if (rnd.Next(1, 11) > 1)    // 1 in 10 chance
                    { map[i, j] = MapContent.ClearSpace; }
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
                    pCount++;
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
                    lCount++;
                }
            }

            // monsters
            int mCount = 0;
            while (mCount < monsterCount)
            {
                x = rnd.Next(1, xDim - 1);
                y = rnd.Next(1, yDim - 1);

                if (map[x, y] == MapContent.ClearSpace)
                {
                    map[x, y] = RandomMonster();
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

        public void PopulateWeather()
        {
            // clear skies everywhere to begin with
            for (int i = 0; i < xDim; i++)
            {
                for (int j = 0; j < yDim; j++)
                {
                    weather[i, j] = WeatherContent.ClearSky;
                }
            }

            // fog
            for (int i = 1; i < weatherInitialCount; i++)
            {
                int x = rnd.Next(0, xDim);
                int y = rnd.Next(0, yDim);
                int height = rnd.Next(3, 7);    //todo magic numbers!
                int width = rnd.Next(3, 7);
                for (int wx = x - width; wx < x + width; wx++)
                {
                    for (int wy = y - height; wy < y + height; wy++)
                    {
                        // if this position is legal, make it foggy
                        if (CoordInRange(wx, wy))
                        {
                            // 1 in 8 chance of undoing it around edges
                            if (rnd.Next(1, 9) != 8) //todo more magic numbers!
                            {
                                weather[wx, wy] = WeatherContent.Fog;
                            }
                        }
                    }
                }

            }

            ResetWind();

        }

        public void ResetWind()
        {
            windXDirection = rnd.Next(-1, 2);
            windYDirection = rnd.Next(-1, 2);
        }


        public void UpdateWeather()
        {
            if (moveCount % weatherUpdateFrequency != 0)
            {
                return;
            }

            int weatherInView = 0;
            for (int x = 0; x < xDim; x++)
            {
                for (int y = 0; y < yDim; y++)
                {
                    int wx = x + windXDirection;
                    int wy = y + windYDirection;

                    // if this position is legal, move it
                    if (CoordInRange(wx, wy))
                    {
                        // 1 in 8 chance of undoing it around edges
                        //if (rnd.Next(1, 9) != 8) //todo more magic numbers!
                        {
                            weather[wx, wy] = weather[x, y];
                            if (weather[x, y] != WeatherContent.ClearSky)
                            {
                                weatherInView++;
                            }
                            weather[x, y] = WeatherContent.ClearSky;
                        }
                    }
                }
            }

            // small chance wind directions might change
            if (rnd.Next(1, 7) == 8)// todo magic numbers again!
            {
                ResetWind();
            }

            // crude for now, if we have too little weather in view, add some
            if (weatherInView < ((int)(xDim * yDim) / 25))
            {
                PopulateWeather(); // need to bring it in from opposite direction of winds etc
            }



        }


        public void Reset()
        {
            PopulateMap();
            PopulateWeather();
            moveCount = 0;

            healthPoints = rnd.Next(550, 1251);
            armourPoints = rnd.Next(10, 101);
            lootPoints = 0;
            combatPoints = rnd.Next(550, 1451);
            foundPrincess = false;

        }

        public GameClass()
        {
            Reset();
        }
    }
}
