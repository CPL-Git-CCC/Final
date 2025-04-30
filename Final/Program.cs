using System;

namespace GemMiningGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create and start the game
            Game game = new Game();
            game.Run();

            // Optional: Keep console open until key press
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}