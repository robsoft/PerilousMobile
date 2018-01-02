using System;
using System.Collections.Generic;

namespace PerilousMobile
{
    public enum GameState
    {
        isReadyToStart,
        isInPlay,
        isOver
    }

    public partial class Game
    {

        // todo start converting these to private fields with get/set etc

        public GameState currentState = GameState.isOver;

        public Random rnd;
		public int xPlayer = 0;
		public int yPlayer = 0;
		public bool playerMoved = false;
		public int moveCount = 0;
		public bool haveMap = false;
		public bool gameOver = false;

		private const int internalVersion = 1;
        private const int xDim = 29;
        private const int yDim = 17;
        private const int noMapViewableSize = 3;

        private const int lootCount = (int)((xDim * yDim) * 0.02);
        private const int monsterCount = (int)((xDim * yDim) * 0.09);
        private const int puzzleCount = 4;//(int)((xDim * yDim) * 0.03);
        private const int weaponCount = (int)((xDim * yDim) * 0.02);
        private const int foodCount = (int)((xDim * yDim) * 0.04);
        private const int healthConsumedPrincess = 8;
        private const int healthConsumedAlone = 5;

		private int optimalHealthPoints = 0;
		public int healthPoints = 0;
		public int armourPoints = 0;
		public int lootPoints = 0;
		public int combatPoints = 0;
		public bool foundPrincess = false;

		private MapContent[,] map = new MapContent[xDim, yDim];

        private List<MonsterClass> monsters = new List<MonsterClass>();
        private List<PuzzleClass> puzzles = new List<PuzzleClass>();
        private List<LootClass> loot = new List<LootClass>();
        private List<WeaponClass> weapons = new List<WeaponClass>();
        private List<FoodClass> food = new List<FoodClass>();

        private void ClearMonsters()
        {
            monsters.Clear();
        }

        private void UpdateMonsters()
        {
            foreach(MonsterClass monster in monsters)
            {
                monster.Heal();
                monster.Move();
            }

        }

        public void ClearCurrentLocation()
        {
            // any clean up?
            switch (map[xPlayer, yPlayer])
                {
                    case MapContent.InvalidSpace:
                        break;
                    case MapContent.ClearSpace:
                        break;
                    case MapContent.PrincessSpace:
                        break;
                    case MapContent.ExitSpace:
                        break;
                    case MapContent.PuzzleSpace:
                        puzzles.Remove(GetCurrentPuzzle());
                        break;
                    case MapContent.LootSpace:
                        GetCurrentLoot().inInventory=true;
                        break;
                    case MapContent.WeaponSpace:
                        GetCurrentWeapon().inInventory=true;
                        break;
                    case MapContent.FoodSpace:
                        food.Remove(GetCurrentFood());
                        break;
                    case MapContent.MonsterSpace:
                        monsters.Remove(GetCurrentMonster());
                        break;
                    default: // fight
                break;
            }
            map[xPlayer, yPlayer] = MapContent.ClearSpace;
        }


        public WeaponClass GetCurrentWeapon()
        {
            return weapons.Find((WeaponClass m) => (m.isAt(xPlayer, yPlayer) == true));
        }
        public FoodClass GetCurrentFood()
        {
            return food.Find((FoodClass m) => (m.isAt(xPlayer, yPlayer) == true));
        }

        public MonsterClass GetCurrentMonster()
        {
            return monsters.Find((MonsterClass m)=>(m.isAt(xPlayer,yPlayer)==true));
        }

        public PuzzleClass GetCurrentPuzzle()
        {
            return puzzles.Find((PuzzleClass m) => (m.isAt(xPlayer, yPlayer) == true));
        }

        public LootClass GetCurrentLoot()
        {
            return loot.Find((LootClass m) => (m.isAt(xPlayer, yPlayer) == true));
        }


        public MapContent CompleteTurn()
        {
            //UpdateWeather();
            UpdateMonsters();
            return (map[xPlayer, yPlayer]);
        }


        public MapContent CurrentLocation()
        {
            return (map[xPlayer, yPlayer]);
        }




        public bool PlayerCanSeeLocation(int x, int y)
        {
            if (haveMap) return true;

            return ((Math.Abs(xPlayer - x) <= noMapViewableSize) && (Math.Abs(yPlayer - y) <= noMapViewableSize));

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

            if ((newx == xPlayer) && (newy == yPlayer)) return;
            // we didn't actually move anywhere new, but don't flag error

            // is it a legal move? Can't be a solid block
            if (map[newx, newy] == MapContent.InvalidSpace) return;

            // update our position and signal we moved
            DecreaseHealthForMove();
            playerMoved = true;
            xPlayer = newx;
            yPlayer = newy;
        }




        public void Reset()
        {
            PopulateMap();
            //PopulateWeather();

            moveCount = 0;
            playerMoved=false;
            haveMap = false;
            foundPrincess = false;
            gameOver = false;

            optimalHealthPoints = rnd.Next(901, 1451);
            healthPoints = optimalHealthPoints;
            armourPoints = rnd.Next(1, 11);
            lootPoints = 50;
            combatPoints = rnd.Next(1, 21);
        }

        public void PrepareToStart()
        {
            // adjust stats here based on selections etc

        }

        public Game()
        {
            // attach to our singleton random class
            rnd = Utils.rnd;

            Reset();
        }
    }
}
