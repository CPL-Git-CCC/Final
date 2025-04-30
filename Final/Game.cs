using System;

namespace GemMiningGame
{
    public class Game
    {
        private Player player;
        private Mine mine;
        private Merchant merchant;
        private bool isRunning;

        public Game()
        {
            player = new Player();
            mine = new Mine();
            merchant = new Merchant();
            isRunning = true;
        }

        public void Run()
        {
            Console.WriteLine("Welcome to Gem Mining Adventure!");
            Console.WriteLine("Mine gems and sell them to upgrade your drill!");

            while (isRunning)
            {
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. Mine for gems");
                Console.WriteLine("2. View inventory");
                Console.WriteLine("3. Visit merchant");
                Console.WriteLine("4. Quit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        MineGems();
                        break;
                    case "2":
                        player.DisplayInventory();
                        break;
                    case "3":
                        VisitMerchant();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }

            Console.WriteLine("Thanks for playing Gem Mining Adventure!");
        }

        private void MineGems()
        {
            Gem gem = mine.MineGem(player.CurrentDrill);
            if (gem != null)
            {
                Console.WriteLine($"You mined a {gem.Name} worth ${gem.Value}!");
                player.AddToInventory(gem);
            }
            else
            {
                Console.WriteLine("You didn't find any gems this time.");
            }
        }

        private void VisitMerchant()
        {
            merchant.DisplayDrills(player);
            Console.WriteLine("Would you like to sell your gems? (y/n)");
            if (Console.ReadLine().ToLower() == "y")
            {
                int total = player.SellAllGems();
                Console.WriteLine($"You sold all your gems for ${total}!");
            }

            Console.WriteLine("Would you like to buy a new drill? (y/n)");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.WriteLine("Enter the number of the drill you want to buy:");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    merchant.SellDrill(player, choice - 1);
                }
                else
                {
                    Console.WriteLine("Invalid selection.");
                }
            }
        }
    }
}