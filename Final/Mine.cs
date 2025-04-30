using System;
using System.Collections.Generic;
using System.Linq;

namespace GemMiningGame
{
    public class Mine
    {
        private Random random;
        private List<Gem> possibleGems;

        public Mine()
        {
            random = new Random();
            possibleGems = new List<Gem>
            {
                new Gem("Quartz", 5, GemRarity.Common),
                new Gem("Topaz", 15, GemRarity.Uncommon),
                new Gem("Sapphire", 30, GemRarity.Rare),
                new Gem("Emerald", 60, GemRarity.Epic),
                new Gem("Diamond", 120, GemRarity.Legendary)
            };
        }

        public Gem MineGem(Drill drill)
        {
            // First determine if we find any gem at all (base 80% chance)
            if (random.Next(1, 101) > 80 - (drill.Tier * 5))
                return null;

            // Weighted random selection based on drill's probabilities
            var weightedGems = possibleGems
                .Where(g => drill.RarityProbabilities.ContainsKey(g.Rarity))
                .Select(g => new
                {
                    Gem = g,
                    Weight = drill.RarityProbabilities[g.Rarity]
                })
                .ToList();

            int totalWeight = weightedGems.Sum(w => w.Weight);
            int randomNumber = random.Next(0, totalWeight);

            foreach (var weightedGem in weightedGems)
            {
                if (randomNumber < weightedGem.Weight)
                    return weightedGem.Gem;
                randomNumber -= weightedGem.Weight;
            }

            return null;
        }
    }
}
