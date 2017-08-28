using System;
namespace PerilousMobile
{
    public class WeaponClass : MapItemClass
    {
		public int combatPoints = 0;

		private WeaponDescriptions description;
		public WeaponKinds kind;

		public string FullDescription()
		{
            return Utils.StripForDisplay(description.ToString() + " " + kind.ToString());
		}

		public WeaponClass(int x, int y) : base(MapContent.WeaponSpace, x, y)
        {

			combatPoints = Utils.rnd.Next(5, 51);

			Array values = Enum.GetValues(typeof(WeaponKinds));
			kind = (WeaponKinds)values.GetValue(Utils.rnd.Next(values.Length));
			values = Enum.GetValues(typeof(WeaponDescriptions));
			description = (WeaponDescriptions)values.GetValue(Utils.rnd.Next(values.Length));

		}

    }
}
