namespace GemMiningGame
{
    public enum GemRarity
    {
        Common = 1,
        Uncommon = 2,
        Rare = 3,
        Epic = 4,
        Legendary = 5
    }

    public class Gem
    {
        public string Name { get; private set; }
        public int Value { get; private set; }
        public GemRarity Rarity { get; private set; }

        public Gem(string name, int value, GemRarity rarity)
        {
            Name = name;
            Value = value;
            Rarity = rarity;
        }
    }
}
