using System;

namespace Models
{
    [Serializable]
    public class ItemData
    {
        public ItemData()
        {
        }

        public ItemData(string name, int amount, int cost)
        {
            Name = name;
            Amount = amount;
            Cost = cost;
        }

        public string Name { get; set; }
        public int Amount { get; set; }
        public int Cost { get; set; }
    }
}