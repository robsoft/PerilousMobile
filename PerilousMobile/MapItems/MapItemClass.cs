using System;
namespace PerilousMobile
{
    public class MapItemClass
	{
        //public SingleRandom randGen = new SingleRandom;


		public int xCoord = 0;
        public int yCoord = 0;
        public MapContent mapContent = MapContent.ClearSpace;

        public string Name;


		public MapItemClass(MapContent map, int x, int y)
        {
            xCoord = x;
            yCoord = y;
            mapContent = map;
            Name = "";
        }

        public bool isAt(int x, int y)
        {
            return ((x == xCoord) && (y == yCoord));
        }
    }
}
