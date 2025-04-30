using System;

namespace GemMiningGame
{
    public class Mine
    {
        private Random random;

        public Mine()
        {
            random = new Random();
        }

        public Gem MineGem(Drill drill)
        {
            int chance = random.Next(1, 101);
            if (chance > 30 - (drill.Tier * 5))
            {
                return null;
            }

            int gemType = random.Next(1, 101);

            if (gemType <= 40 - (drill.Tier * 3))
            {
                return new Gem("Quartz", 5, 1);
            }
            else if (gemType <= 70 - (drill.Tier * 2))
            {
                return new Gem("Topaz", 15, 2);
            }
            else if (gemType <= 90 - drill.Tier)
            {
                return new Gem("Sapphire", 30, 3);
            }
            else
            {
                return new Gem("Diamond", 75, 4);
            }
        }
    }
}