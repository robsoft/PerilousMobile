using System;
namespace PerilousMobile
{
    public class LootClass : MapItemClass
    {

        public int lootPoints = 0;
        public bool inInventory = false;

		private LootDescriptions description;
		public LootKinds kind;

		public string FullDescription()
		{
			return Utils.StripForDisplay(description.ToString() + " " + kind.ToString());
		}

        public LootClass(int x, int y) : base(MapContent.LootSpace, x, y)
        {

            lootPoints = Utils.rnd.Next(5, 501);

			Array values = Enum.GetValues(typeof(LootKinds));
			kind = (LootKinds)values.GetValue(Utils.rnd.Next(values.Length));
			values = Enum.GetValues(typeof(LootDescriptions));
			description = (LootDescriptions)values.GetValue(Utils.rnd.Next(values.Length));

		}
    }
}
