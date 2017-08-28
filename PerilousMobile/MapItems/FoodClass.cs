using System;
namespace PerilousMobile
{
    public class FoodClass : MapItemClass
    {
		public int healthPoints = 0;

		private FoodDescriptions description;
		public FoodKinds kind;

		public string FullDescription()
		{
			return Utils.StripForDisplay(description.ToString() + " " + kind.ToString());
		}

		public FoodClass(int x, int y) : base(MapContent.FoodSpace, x, y)
		{

			healthPoints = Utils.rnd.Next(5, 101);

			Array values = Enum.GetValues(typeof(FoodKinds));
			kind = (FoodKinds)values.GetValue(Utils.rnd.Next(values.Length));
			values = Enum.GetValues(typeof(FoodDescriptions));
			description = (FoodDescriptions)values.GetValue(Utils.rnd.Next(values.Length));

		}
	}

}
