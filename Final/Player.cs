using System;
using System.Collections.Generic;

namespace GemMiningGame
{
    public class Player
    {
        public List<Gem> Inventory { get; private set; }
        public Drill CurrentDrill { get; private set; }
        public int Money { get; private set; }

        public Player()
        {
            Inventory = new List<Gem>();
            Money = 0;
            
            // Initialize with basic drill
            var merchant = new Merchant();
            CurrentDrill = merchant.availableDrills[0];
        }
        public void AddToInventory(Gem gem)
        {
            Inventory.Add(gem);
        }

        public int SellAllGems()
        {
            int total = 0;
            foreach (var gem in Inventory)
            {
                total += gem.Value;
            }
            Money += total;
            Inventory.Clear();
            return total;
        }

        public void DisplayInventory()
        {
            Console.WriteLine("\n--- Your Inventory ---");
            Console.WriteLine($"Current Drill: {CurrentDrill.Name} (Tier {CurrentDrill.Tier})");
            Console.WriteLine($"Money: ${Money}");

            if (Inventory.Count == 0)
            {
                Console.WriteLine("You have no gems.");
                return;
            }

            var gemCounts = new Dictionary<string, int>();
            foreach (var gem in Inventory)
            {
                if (gemCounts.ContainsKey(gem.Name))
                {
                    gemCounts[gem.Name]++;
                }
                else
                {
                    gemCounts[gem.Name] = 1;
                }
            }

            foreach (var pair in gemCounts)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }

        public bool PurchaseDrill(Drill drill)
        {
            if (Money >= drill.Cost)
            {
                Money -= drill.Cost;
                CurrentDrill = drill;
                return true;
            }
            return false;
        }
    }
}
