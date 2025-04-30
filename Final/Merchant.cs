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
                new Drill("Basic Drill", 1, 0),
                new Drill("Bronze Drill", 2, 100),
                new Drill("Silver Drill", 3, 300),
                new Drill("Gold Drill", 4, 750),
                new Drill("Platinum Drill", 5, 2000),
                new Drill("Diamond Drill", 6, 5000)
            };
        }

        public void DisplayDrills(Player player)
        {
            Console.WriteLine("\n--- Available Drills ---");
            for (int i = 0; i < availableDrills.Count; i++)
            {
                string owned = (player.CurrentDrill.Name == availableDrills[i].Name) ? "(OWNED)" : "";
                string afford = (player.Money >= availableDrills[i].Cost) ? "" : "(Can't afford)";
                Console.WriteLine($"{i + 1}. {availableDrills[i].Name} - Tier {availableDrills[i].Tier} - ${availableDrills[i].Cost} {owned} {afford}");
            }
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