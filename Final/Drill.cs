namespace GemMiningGame
{
    public class Drill
    {
        public string Name { get; private set; }
        public int Tier { get; private set; }
        public int Cost { get; private set; }
        public Dictionary<GemRarity, int> RarityProbabilities { get; private set; }

        public Drill(string name, int tier, int cost, Dictionary<GemRarity, int> rarityProbabilities)
        {
            Name = name;
            Tier = tier;
            Cost = cost;
            RarityProbabilities = rarityProbabilities;
        }
    }
}
