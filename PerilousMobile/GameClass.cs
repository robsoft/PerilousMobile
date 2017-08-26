using System;
namespace PerilousMobile
{
    public class GameClass
    {
        private const int xDim = 30;
        private const int yDim = 20;
        private const int lootCount = (int)((xDim * yDim) * 0.04);
        private const int monsterCount = (int)((xDim * yDim) * 0.1);
        private const int puzzleCount = (int)((xDim * yDim) * 0.07);
        //private const int monsterTypes = 14;

        private int[,] map = new int[xDim, yDim];
        private Random rnd = new Random();

        private string[] decodeMap = new string[20] { "X", " ", "P", "E", "?", "L", "M", "M", "M", "M",
          "M","M","M","M","M","M","M","M","M","M"};

        public int xPlayer = 0;
        public int yPlayer = 0;
        public bool playerMoved = false;

        public int CompleteMove()
        {
            return (map[xPlayer, yPlayer]);
        }

        public int CurrentLocation()
        {
			return (map[xPlayer, yPlayer]);
		}
        public bool RunMove()
        {
            // randomly choose a valid adjacent location
            return true;   
        }

        public int FightMove(int hitPoints)
        {
            // decide if we've beaten this dude etc
            return 0;
        }



        public bool MovePlayerText(string move)
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
                return false;

            if ((newx == xPlayer) && (newy == yPlayer))
            { return true; }    // we didn't actually move, but don't flag error

            // is it a legal move? Can't be a solid block
            if (map[newx, newy] == 0)
            {
                return false;
            }

            // update our position and signal we moved
            playerMoved = true;
            xPlayer = newx;
            yPlayer = newy;
            return true;
        }

        private string GetLineAsText(int line)
        {
            string lineText = "";

            for (int x = 0; x < xDim; x++)
            {
                if ((line == yPlayer) && (x == xPlayer))
                {
                    lineText = lineText + "*";
                }
                else
                {
                    lineText = lineText + decodeMap[map[x, line]];
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
                    map[i, j] = 0;
                }
            }

            // small chance of an inner block NOT being cleared
            for (int i = 1; i < (xDim - 1); i++)
            {
                for (int j = 1; j < (yDim - 1); j++)
                {
                    if (rnd.Next(1, 10) > 1)
                    { map[i, j] = 1; }
                }
            }

            // princess
            int x = rnd.Next(2, xDim - 2);
            int y = rnd.Next(2, yDim - 2);
            map[x, y] = 2;

            // entrance/exit
            // top or bottom
            int eCount = rnd.Next(1, 3);    // ie 1 or 2 sets of '2'
            for (int i = 0; i <= eCount; i++)
            {
                do
                {
                    x = (xDim - 1) * rnd.Next(0, 2);    // ie, 0 or xDim-1
                    y = rnd.Next(1, yDim - 1);
                    if (map[x, y] == 0)
                    {
                        map[x, y] = 3;
                        break;
                    }
                } while (true);  //(map[x, y] != 3);

                do
                {
                    x = rnd.Next(1, xDim - 1);
                    y = (yDim - 1) * rnd.Next(0, 2);    // ie, 0 or yDim-1
                    if (map[x, y] == 0)
                    {
                        map[x, y] = 3;
                        break;
                    }
                } while (true);  //map[x, y] != 3);

            }

            // puzzles
            int pCount = 0;
            while (pCount < puzzleCount)
            {
                x = rnd.Next(1, xDim - 1);
                y = rnd.Next(1, yDim - 1);

                if (map[x, y] == 1)
                {
                    map[x, y] = 4;
                    pCount++;
                }
            }

            // loot
            int lCount = 0;
            while (lCount < lootCount)
            {
                x = rnd.Next(1, xDim - 1);
                y = rnd.Next(1, yDim - 1);

                if (map[x, y] == 1)
                {
                    map[x, y] = 5;
                    lCount++;
                }
            }

			// monsters
			int mCount = 0;
			while (mCount < monsterCount)
			{
				x = rnd.Next(1, xDim - 1);
				y = rnd.Next(1, yDim - 1);

				if (map[x, y] == 1)
				{
					map[x, y] = rnd.Next(6,20);
					mCount++;
				}
			}

			// now position the dude
			do
            {
                x = (xDim - 1) * rnd.Next(0, 2);    // ie, 0 or xDim-1
                y = rnd.Next(1, yDim - 1);
                if (map[x, y] == 3)
                {
                    xPlayer = x;
                    yPlayer = y;
                    break;
                }
            } while (true);//

        }


        public GameClass()
        {
            PopulateMap();


        }
    }
}
