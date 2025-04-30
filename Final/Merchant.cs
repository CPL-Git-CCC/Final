using System.Collections.Generic;

namespace GemMiningGame
{
    public class Merchant
    {
        private List<Drill> availableDrills;

        public Merchant()
        {
            availableDrills = new List<Drill>
            {
                new Drill("Basic Drill", 1, 0, new Dictionary<GemRarity, int>
                {
                    { GemRarity.Common, 100 },
                    { GemRarity.Uncommon, 0 },
                    { GemRarity.Rare, 0 },
                    { GemRarity.Epic, 0 },
                    { GemRarity.Legendary, 0 }
                }),
                new Drill("Bronze Drill", 2, 100, new Dictionary<GemRarity, int>
                {
                    { GemRarity.Common, 70 },
                    { GemRarity.Uncommon, 30 },
                    { GemRarity.Rare, 0 },
                    { GemRarity.Epic, 0 },
                    { GemRarity.Legendary, 0 }
                }),
                new Drill("Silver Drill", 3, 300, new Dictionary<GemRarity, int>
                {
                    { GemRarity.Common, 50 },
                    { GemRarity.Uncommon, 35 },
                    { GemRarity.Rare, 15 },
                    { GemRarity.Epic, 0 },
                    { GemRarity.Legendary, 0 }
                }),
                new Drill("Gold Drill", 4, 750, new Dictionary<GemRarity, int>
                {
                    { GemRarity.Common, 30 },
                    { GemRarity.Uncommon, 40 },
                    { GemRarity.Rare, 25 },
                    { GemRarity.Epic, 5 },
                    { GemRarity.Legendary, 0 }
                }),
                new Drill("Platinum Drill", 5, 2000, new Dictionary<GemRarity, int>
                {
                    { GemRarity.Common, 20 },
                    { GemRarity.Uncommon, 30 },
                    { GemRarity.Rare, 35 },
                    { GemRarity.Epic, 15 },
                    { GemRarity.Legendary, 0 }
                }),
                new Drill("Diamond Drill", 6, 5000, new Dictionary<GemRarity, int>
                {
                    { GemRarity.Common, 10 },
                    { GemRarity.Uncommon, 20 },
                    { GemRarity.Rare, 30 },
                    { GemRarity.Epic, 25 },
                    { GemRarity.Legendary, 15 }
                })
            };
        }

        public void SellDrill(Player player, int index)
        {
            if (index < 0 || index >= availableDrills.Count)
            {
                Console.WriteLine("Invalid drill selection.");
                return;
            }

            Drill selectedDrill = availableDrills[index];

            if (player.CurrentDrill.Tier >= selectedDrill.Tier)
            {
                Console.WriteLine("You already have an equal or better drill!");
                return;
            }

            if (player.PurchaseDrill(selectedDrill))
            {
                Console.WriteLine($"Congratulations! You purchased the {selectedDrill.Name}!");
            }
            else
            {
                Console.WriteLine("You don't have enough money for that drill.");
            }
        }
    }
}
