using System;
namespace PerilousMobile
{
    public class PuzzleClass : MapItemClass
    {

        public int healthPoints = 0;
        public int lootPoints = 0;
        public int combatPoints = 0;
        public int armourPoints = 0;

        private PuzzleDescriptions description;
        public PuzzleKinds kind;

        public string FullDescription()
        {
            return Utils.StripForDisplay(description.ToString() + " " + kind.ToString());

        }

        public PuzzleClass(int x, int y) : base(MapContent.PuzzleSpace, x, y)
        {

            healthPoints = Utils.rnd.Next(5, 101);
            lootPoints = Utils.rnd.Next(5, 201);
            combatPoints = Utils.rnd.Next(5, 11);
            armourPoints = Utils.rnd.Next(5, 11);

            Array values = Enum.GetValues(typeof(PuzzleKinds));
            kind = (PuzzleKinds)values.GetValue(Utils.rnd.Next(values.Length));
            values = Enum.GetValues(typeof(PuzzleDescriptions));
            description = (PuzzleDescriptions)values.GetValue(Utils.rnd.Next(values.Length));

        }
    }


}
