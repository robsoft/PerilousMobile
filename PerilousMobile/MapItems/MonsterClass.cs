using System;
namespace PerilousMobile
{
    public class MonsterClass : MapItemClass
    {

        public int optimalHealthPoints = 0;
        public int healthPoints = 0;
        public int combatPoints = 0;
        public int lootPoints = 0;

        //public Item itemCarried = Item.Nothing;
        public bool isHealing = false;
        public bool isMoving = false;

        private MonsterDescriptions description;
        public MonsterKinds kind;

        public string FullDescription()
        {
            return Utils.StripForDisplay(description.ToString() + " " + kind.ToString());

        }

        public void Heal()
        {
            if (isHealing)
            {
                healthPoints = Utils.rnd.Next(healthPoints + 1, optimalHealthPoints + 1);
                isHealing = (healthPoints < optimalHealthPoints);
            }
        }

        public void Move()
        {
            // nothing yet
        }

        public MonsterClass(int x, int y) : base(MapContent.MonsterSpace, x, y)
        {
            optimalHealthPoints = Utils.rnd.Next(225, 1111);
            healthPoints = optimalHealthPoints;
            combatPoints = Utils.rnd.Next(10, 401);
            lootPoints = Utils.rnd.Next(0, 201);

            Array values = Enum.GetValues(typeof(MonsterKinds));
            kind = (MonsterKinds)values.GetValue(Utils.rnd.Next(values.Length));
            values = Enum.GetValues(typeof(MonsterDescriptions));
            description = (MonsterDescriptions)values.GetValue(Utils.rnd.Next(values.Length));

        }
    }
}
