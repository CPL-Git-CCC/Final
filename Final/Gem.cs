namespace GemMiningGame
{
    public class Gem
    {
        public string Name { get; private set; }
        public int Value { get; private set; }
        public int Rarity { get; private set; }

        public Gem(string name, int value, int rarity)
        {
            Name = name;
            Value = value;
            Rarity = rarity;
        }
    }
}